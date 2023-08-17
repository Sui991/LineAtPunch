using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LineAtPunch.Models
{
    public class SignInViewModel
    {
        //帳號
        public string UserEmail { get; set; }
        //密碼
        public string Password { get; set; }
    }
}