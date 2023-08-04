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

        public Boolean Login(string employeeId,string password)
        {
            Account_DataTable employee = DB.Account_DataTable.FirstOrDefault(a => a.Employee_Id == employeeId && a.Password == password);
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