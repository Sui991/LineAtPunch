using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TT.EFModels;
using TT.Models;
using System.Text;
namespace TT.Controllers
{
    public class ExportToCSVController : ApiController
    {
        // GET: PersonalPunchRecord
     

        [HttpGet]
        public IHttpActionResult ExportToCSV()
        {
            //var SearchPunch_List = PunchRecord_List.Where(a => a.id == id).ToList();
            MemoryStream memoryStream = new MemoryStream();
            Model_WriteToCSV model_WriteToCSV = new Model_WriteToCSV();
            model_WriteToCSV.WriteToCSV(memoryStream);
           
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new ByteArrayContent(memoryStream.ToArray());
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/csv");
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = "data.csv"; // 檔案名稱
            return  ResponseMessage(response);
        }

    }
}