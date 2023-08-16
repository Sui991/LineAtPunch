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

    [JwtAuthActionFilter]
    [RoutePrefix("api/PersonalPunchRecord")]
    public class PersonalPunchRecordController : ApiController
    {
        Model_PunchRecordSearch model_PRSearch = new Model_PunchRecordSearch();
        // GET: PersonalPunchRecord
        [Route("{id:int}")]
        [HttpGet]

        public List<vw_PunchRecord> PunchRecordSearch(int id)
        {
            model_PRSearch.Record_Search(id);
            var SearchResult = model_PRSearch.Log_List;
            return SearchResult;
        }
        [JwtAuthActionFilter]
        [HttpGet]
        [Route("")]
        public List<vw_PunchRecord> GetAllPunchRecordSearch(string employeeId)
        {
            //建立查詢物件
            //呼叫model中的查詢員工所有打卡紀錄方法
            model_PRSearch.GetAllRecord(employeeId);
            var result = model_PRSearch.Log_List;
            return result;
        }

    }
}