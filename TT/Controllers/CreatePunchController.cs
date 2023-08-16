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
    [RoutePrefix("api/CreatePunch")]
    public class CreatePunchController : ApiController
    {
        // GET: PersonalPunchRecord
        readonly Model_PunchRecordCreate model_PunchRecordCreate = new Model_PunchRecordCreate();

        [Route("")]
        [HttpPost]

        public string CreaetePunch(PunchRecord_Table punchRecord_Table)
        {

            model_PunchRecordCreate.CreatePunch(punchRecord_Table);
            return model_PunchRecordCreate.tbl_punch.id.ToString();
        }

    }
}