using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LineAtPunch.EFModels;
using LineAtPunch.Models;
using System.Text;
namespace LineAtPunch.Controllers
{
    [JwtAuthActionFilter]
    [RoutePrefix("api/ExportToCSV")]
    public class ExportToCSVController : ApiController
    {


        [Route("")]
        [HttpGet]
        public IHttpActionResult ExportToCSV()
        {
            
            MemoryStream memoryStream = new MemoryStream();
            Model_WriteToCSV model_WriteToCSV = new Model_WriteToCSV();
            model_WriteToCSV.WriteToCSV(memoryStream);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new ByteArrayContent(memoryStream.ToArray());
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/csv");//輸出格式
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = "data.csv"; // 檔案名稱
            return ResponseMessage(response);
        }

    }
}