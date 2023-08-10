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
    public class PersonalPunchRecordController : ApiController
    {
        // GET: PersonalPunchRecord
      
        [HttpGet, ActionName("GetAllPersonalPunchRecord")]

        public List<PunchRecord_Table> GetAllPersonalPunchRecord(string strEmployeeID)
        {
            Model_PunchRecordSearch model_PRSearch = new Model_PunchRecordSearch();

            model_PRSearch.GetAllRecord(strEmployeeID);
            var result = model_PRSearch.Log_List;
            return result;
        }

    }
}