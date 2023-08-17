using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TT.EFModels;
using TT.Models;
namespace TT.Controllers
{
    [JwtAuthActionFilter]
    [RoutePrefix("api/AccountEdit")]
    public class AccountEditController : ApiController
    {
        // GET: PersonalPunchRecord


        [Route("AllAcountSearch")]
        [HttpGet]


        public List<AccountData_Table> AllAcountSearch()
        {
            //給後台管理者用 獲取所有員工資料
            Model_AccountEdit model_AccountEdit = new Model_AccountEdit();
            model_AccountEdit.GetAllAccount();
            return model_AccountEdit.AllData;
        }

        [Route("")]
        [HttpPut]
        //一般使用者參數輸入欲更改的信箱、密碼、電話號碼 輸入其他欄位值不會變
        //管理者參數 根據前端修改按鈕得到欲更改的員工id 欄位均可修改
        public AccountData_Table AccountEdit( Model_AccountEdit.NewAccountData newAccountData )
        {
            Model_AccountEdit model_AccountEdit = new Model_AccountEdit();
            //從登入token裡提取員工id、成員類型
            var employeeId = HttpContext.Current.Items["EmployeeId"] as string;
            var AccountType = HttpContext.Current.Items["AccountType"] as string;
            //根據員工id找出要更新的資料表

            //若員工的成員類別為一般使用者的話 只能更改限定欄位
            if (AccountType == "1")
            {

                model_AccountEdit.GetAccount(employeeId);

                model_AccountEdit.UserEditAccount(newAccountData);

            }
            //若員工的成員類別為管理者的話 擁有所有更改權限
            else if (AccountType == "2")
            {
                model_AccountEdit.GetAllAccount();
                model_AccountEdit.GetAccount(newAccountData.employeeId);
                model_AccountEdit.adminEditAccount(newAccountData);
            }

            //將資料回傳給前端 資料型態為物件轉json
            var EditedResult = model_AccountEdit.UpdateData;
            return EditedResult;
        }

    }
}