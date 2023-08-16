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
        public Boolean Login(SignInViewModel signInViewModel)
        {
            employee = DB.AccountData_Table.FirstOrDefault(a => a.account_email == signInViewModel.UserEmail && a.account_password == signInViewModel.Password);
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