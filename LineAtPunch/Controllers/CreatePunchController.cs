using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LineAtPunch.EFModels;
using LineAtPunch.Models;
namespace LineAtPunch.Controllers
{
    [JwtAuthActionFilter]
    [RoutePrefix("api/CreatePunch")]
    public class CreatePunchController : ApiController
    {
        // 
        readonly Model_PunchRecordCreate model_PunchRecordCreate = new Model_PunchRecordCreate();

        [Route("")]
        [HttpPost]

        public string CreaetePunch(PunchRecord_Table punchRecord_Table)
        {
            //新增打卡資料紀錄
            model_PunchRecordCreate.CreatePunch(punchRecord_Table);

            //回傳給前端資料的id 可以根據這id點選按鈕導覽至修改頁面
            return model_PunchRecordCreate.tbl_punch.id.ToString();
        }

    }
}