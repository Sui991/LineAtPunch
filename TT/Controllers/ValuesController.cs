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
    public class ValuesController : ApiController
    {
        // GET api/values
        LineAtDBEntities DB = new LineAtDBEntities();
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        //public string Get(int id)
        //{
        //    return "ok";
        //}

   
        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        //[HttpGet]

        //public IHttpActionResult SendEmail(string emails, string title, string content/*, string paths*/)
        //{
        //    GMailAdapter gMailAdapter = new GMailAdapter();

        //    gMailAdapter.SendMail(emails, title,content/*,paths*/);

        //    return Ok("nice job bro");
        //}
        [HttpGet]

        public List<PunchRecord_Table> PunchRecordSearch(int intID)
        {
            Model_PunchRecordSearch model_PRSearch = new Model_PunchRecordSearch();

            model_PRSearch.Record_Search(intID);
            var SearchResult = model_PRSearch.Log_List;
            return SearchResult;     
        }


        [HttpGet]

        public IHttpActionResult Login(string employeeId, string password)
        {
            // 查詢該員工帳號是否存在並檢查密碼是否正確
            Model_Login model_Login = new Model_Login();

           var Login_result = model_Login.Login(employeeId, password);

            if (Login_result)
            {
                return Ok("你好呀");
            }
            else
            {

                return BadRequest("帳號或密碼不正確");
            }
        }
    }
}
