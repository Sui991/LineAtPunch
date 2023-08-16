//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using TT.EFModels;
//using TT.Models;
//namespace TT.Controllers
//{
//    public class AccountEditController : ApiController
//    {
//        // GET: PersonalPunchRecord

//        [HttpPut]

//        public AccountData_Table AccountEdit(int memberType,string EmployeeID, string NewPassword, string NewPhoneNumber, string NewEmail)
//        {
//            Model_AccountEdit model_AccountEdit = new Model_AccountEdit();
//            model_AccountEdit.GetAccount(strEmployeeID);
//            model_AccountEdit.EditAccount(strNewPassword, strNewPhoneNumber, strNewEmail);
//            var EditedResult = model_AccountEdit.UpdateData;
//            return EditedResult;
//        }

//    }
//}