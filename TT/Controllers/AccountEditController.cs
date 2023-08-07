using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TT.EFModels;
using TT.Models;
namespace TT.Controllers
{
    public class AccountEditController : ApiController
    {
        // GET: PersonalPunchRecord
       
        [HttpPut]

        public Account_DataTable AccountEdit(string employeeID, string NewPassword, string NewPhoneNumber, string NewEmail)
        {
            Model_AccountEdit model_AccountEdit = new Model_AccountEdit();
            model_AccountEdit.GetAccount(employeeID);
            model_AccountEdit.EditAccount(NewPassword, NewPhoneNumber, NewEmail);
            var EditedResult = model_AccountEdit.UpdateData;
            return EditedResult;
        }

    }
}