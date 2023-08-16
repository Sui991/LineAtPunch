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
        public AccountData_Table UpdateData { get; set; }
        public List<AccountData_Table> AllData { get; set; }
        public Model_AccountEdit()
        {
            NewAccountData newAccountData = new NewAccountData();
        }
        public class NewAccountData
        {
            public int memberType { get; set; }
            public string employeeId { get; set; }
           public string NewEmail { get; set; }
            public string NewPassword { get; set; }
            public string NewDepartment { get; set; }
            public int NewaccountTypeId { get; set; }
            public string NewName { get; set; }
            public string NewPhone { get; set; }

            public int id { get; set; }
            public string NewPosition { get; set; }
        }
        public void GetAccount(string employeeId)
        {
            this.UpdateData = DB.AccountData_Table.Where(x => x.account_employee_id == employeeId).FirstOrDefault();
        }

        public void GetAllAccount()
        {
            this.AllData = DB.AccountData_Table.ToList();
        }
        public void UserEditAccount(NewAccountData newAccountData)
        {
            //一般使用者只能更新信箱、密碼、電話號碼
            //若前端傳過來的值不為空的話 更新帳戶資料 
            if (!string.IsNullOrEmpty(newAccountData.NewPassword))
            {
                this.UpdateData.account_password = newAccountData.NewPassword;
            }
            if (!string.IsNullOrEmpty(newAccountData.NewPhone))
            {
                this.UpdateData.account_phone = newAccountData.NewPhone;
            }
            if (!string.IsNullOrEmpty(newAccountData.NewEmail))
            {
                this.UpdateData.account_email = newAccountData.NewEmail;
            }
            DB.SaveChanges();
        }
        public void adminEditAccount(NewAccountData newAccountData)
        {
            //管理者擁有所有更新權限
            //若前端傳過來的值不為空的話 更新帳戶資料
            this.UpdateData = AllData.Where(a => a.id == newAccountData.id).FirstOrDefault();

            if (!string.IsNullOrEmpty(newAccountData.NewPassword))
            {
                this.UpdateData.account_password = newAccountData.NewPassword;
            }
            if (!string.IsNullOrEmpty(newAccountData.NewPhone))
            {
                this.UpdateData.account_phone = newAccountData.NewPhone;
            }
            if (!string.IsNullOrEmpty(newAccountData.NewEmail))
            {
                this.UpdateData.account_email = newAccountData.NewEmail;
            }
            if (!string.IsNullOrEmpty(newAccountData.NewName))
            {
                this.UpdateData.account_name = newAccountData.NewName;
            }
            if (!string.IsNullOrEmpty(newAccountData.NewDepartment))
            {
                this.UpdateData.account_department = newAccountData.NewDepartment;
            }
            if (!string.IsNullOrEmpty(newAccountData.NewPosition))
            {
                this.UpdateData.account_position = newAccountData.NewPosition;
            }
            DB.SaveChanges();
        }





    }

}