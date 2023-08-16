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
            Model_AccountEdit model_AccountEdit = new Model_AccountEdit();
            model_AccountEdit.GetAllAccount();
            return model_AccountEdit.AllData;
        }
        [Route("")]
        [HttpPut]

        public AccountData_Table AccountEdit( Model_AccountEdit.NewAccountData newAccountData )
        {
            Model_AccountEdit model_AccountEdit = new Model_AccountEdit();
            //從登入token裡提取員工id
            var employeeId = HttpContext.Current.Items["EmployeeId"] as string;

            //根據員工id找出要更新的資料表
            model_AccountEdit.GetAccount(newAccountData.employeeId);

            //若員工的成員類別為一般使用者的話 只能更改限定欄位
            if (model_AccountEdit.UpdateData.accountType_id == 1)
            {
                model_AccountEdit.UserEditAccount(newAccountData);

            }
            //若員工的成員類別為管理者的話 擁有所有更改權限
            else if (model_AccountEdit.UpdateData.accountType_id == 2)
            {
                model_AccountEdit.adminEditAccount(newAccountData);
            }

            //將資料回傳給前端 資料型態為物件轉json
            var EditedResult = model_AccountEdit.UpdateData;
            return EditedResult;
        }

    }
}