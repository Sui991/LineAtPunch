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
    public class ExportToCSVController : ApiController
    {
        // GET: PersonalPunchRecord
     

        [HttpGet]
        public string ExportToCSV(string filepath)
        {
            //var SearchPunch_List = PunchRecord_List.Where(a => a.id == id).ToList();

            Model_WriteToCSV model_WriteToCSV = new Model_WriteToCSV();
            model_WriteToCSV.WriteToCSV(filepath);
            return "建立成功";
        }

    }
}