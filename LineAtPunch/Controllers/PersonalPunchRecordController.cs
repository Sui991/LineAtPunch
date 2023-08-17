using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using LineAtPunch.EFModels;
using LineAtPunch.Models;
namespace LineAtPunch.Controllers
{
    
    [JwtAuthActionFilter]
    //domain/api/PersonalPunchRecord
    [RoutePrefix("api/PersonalPunchRecord")]
    public class PersonalPunchRecordController : ApiController
    {
        Model_PunchRecordSearch model_PRSearch = new Model_PunchRecordSearch();
        // GET: domain/api/PersonalPunchRecord/id
        [Route("{id:int}")]
        [HttpGet]
        //根據打卡紀錄清單裡的按鈕獲得id 並搜尋個人打卡紀錄
        public List<vw_PunchRecord> PunchRecordSearch(int id)
        {
            model_PRSearch.Record_Search(id);
            var SearchResult = model_PRSearch.Log_List;
            return SearchResult;
        }

    

        [HttpGet]
        [Route("")]
        public List<vw_PunchRecord> GetAllPunchRecordSearch()
        {
            //建立查詢物件
            //呼叫model中的查詢員工所有打卡紀錄方法
            var employeeId = HttpContext.Current.Items["EmployeeId"] as string;
            model_PRSearch.GetAllRecord(employeeId);
            var result = model_PRSearch.Log_List;
            return result;
        }

    }
}