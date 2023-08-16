using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TT.EFModels;
namespace TT.Models
{
    public class Model_PunchRecordCreate
    {
        private LineAtDBEntities DB = new LineAtDBEntities();
       public PunchRecord_Table tbl_punch { get; set; }
        public Model_PunchRecordCreate()
        {
        }
        //public override string ToString()
        //{

        //    return String.Format("address: {0},notes:: {1},img:{2},A_ID:{3},type:{4},id:{5},datetime:{6}", tbl_punch.punch_addr, tbl_punch.punch_notes, tbl_punch.punch_img, tbl_punch.punch_employee_id, tbl_punch.punch_type_id, tbl_punch.punch_id, tbl_punch.punch_datetime);
        //}

        public void CreatePunch(PunchRecord_Table punchRecord_Table)
        {
            //打卡時間為當下時間
            punchRecord_Table.punch_datetime = DateTime.Now;
            tbl_punch = punchRecord_Table;
            DB.PunchRecord_Table.Add(tbl_punch);
            DB.SaveChanges();
        }



    }

}





