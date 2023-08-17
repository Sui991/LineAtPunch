using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TT.EFModels;
namespace TT.Models
{
    public class Model_Login
    {
        private LineAtDBEntities DB = new LineAtDBEntities();
        public AccountData_Table employee { get; set; }

        public string auth_employeeid { get; set; }
        public int auth_memberType { get; set; }
        public Boolean Login(SignInViewModel signInViewModel)
        {
            //根據登入資訊 獲取相對應的員工編號以及成員類型 以便之後操作Api的驗證身分用
            employee = DB.AccountData_Table.FirstOrDefault(a => a.account_email == signInViewModel.UserEmail && a.account_password == signInViewModel.Password);
            auth_employeeid = employee.account_employee_id;
            auth_memberType = employee.accountType_id;
            if (employee == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


    }


}