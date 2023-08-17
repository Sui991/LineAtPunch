using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LineAtPunch.Models
{
    public class User
    {
        //流水號
        public int Id { get; set; }
        //帳號
        public string UserEmail { get; set; }
        //名稱
        public string UserName { get; set; }
        

        //獲取員工ID  
        public string auth_employeeId { get; set; }

        //獲取員工的成員類型 權限用
        public string auth_accountType { get; set; }

        //public Identity Identity { get; set; }
    }
    //public enum Identity
    //{
    //    [Description("管理者")]
    //    Admin = 1,

    //    [Description("一般使用者")]
    //    User = 2,
    //}
}