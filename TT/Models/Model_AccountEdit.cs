using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TT.EFModels;
namespace TT.Models
{
    public class Model_AccountEdit
    {
        private LineAtDBEntities DB = new LineAtDBEntities();
        public Account_DataTable UpdateData { get; set; }
        public Model_AccountEdit() 
        {
        }

        public void GetAccount(string employeeID)
        {
            this.UpdateData = DB.Account_DataTable.Where(x => x.Employee_Id == employeeID).FirstOrDefault();
        }
        public void EditAccount(string NewPassword, string NewPhoneNumber, string NewEmail)
        {
            if (NewPassword != null)
            {
                this.UpdateData.Password = NewPassword;
            }
            if (NewPhoneNumber != null)
            {
                this.UpdateData.PhoneNumber = NewPhoneNumber;
            }
            if (NewEmail != null)
            {
                this.UpdateData.Email = NewEmail;
            }
            DB.SaveChanges();
        }





    }
    
}