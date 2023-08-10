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

        public PunchRecord_Table PunchEdit(int intID ,string strEmployeeID,string strNotes, byte[] img, string strType )
        {
            Model_PunchRecordEdit model_punchRecordEdit = new Model_PunchRecordEdit();
            model_punchRecordEdit.GetPunchData(strEmployeeID, intID);
            model_punchRecordEdit.EditPunch(strNotes, img, strType);
            var EditedResult = model_punchRecordEdit.UpdateData;
            return EditedResult;
        }

    }
}