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
    [RoutePrefix("api/PunchEdit")]
    public class PunchEditController : ApiController
    {
        // GET: PersonalPunchRecord
        [Route("")]
        [HttpPut]

        public PunchRecord_Table PunchEdit(int ID, string EmployeeID, string Notes, string img, int Type)
        {
            Model_PunchRecordEdit model_punchRecordEdit = new Model_PunchRecordEdit();
            model_punchRecordEdit.GetPunchData(EmployeeID, ID);
            model_punchRecordEdit.EditPunch(Notes, img, Type);
            var EditedResult = model_punchRecordEdit.UpdateData;
            return EditedResult;
        }

    }
}