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
    public class PunchEditController : ApiController
    {
        // GET: PersonalPunchRecord
       
        [HttpPut]

        public PunchRecord_Table PunchEdit(int id ,string employeeID,string notes, byte[] img, string type)
        {
            Model_PunchRecordEdit model_punchRecordEdit = new Model_PunchRecordEdit();
            model_punchRecordEdit.GetPunchData(employeeID, id);
            model_punchRecordEdit.EditPunch(notes, img, type);
            var EditedResult = model_punchRecordEdit.UpdateData;
            return EditedResult;
        }

    }
}