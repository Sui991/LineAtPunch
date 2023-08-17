using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LineAtPunch.EFModels;
namespace LineAtPunch.Models
{
    public class Model_PunchRecordEdit
    {
        private LineAtDBEntities DB = new LineAtDBEntities();
        public PunchRecord_Table UpdateData { get; set; }
        public Model_PunchRecordEdit()
        {
        }
        //public override string ToString()
        //{

        //    return String.Format("address: {0},notes:: {1},img:{2},A_ID:{3},type:{4},id:{5},datetime:{6}",punch.address,punch.notes,punch.img,punch.A_ID,punch.type,punch.id,punch.datetime);
        //}
        public void GetPunchData(string strEmployeeID, int intId)
        {
            //根據登入的員工編號 只能修改對應的員工編號 不能改其他人的打卡紀錄
            var editData = DB.vw_PunchRecord.Where(x => x.vw_employee == strEmployeeID && x.id == intId).FirstOrDefault();
            this.UpdateData = DB.PunchRecord_Table.Where(x => x.id == editData.id).FirstOrDefault();
        }
        public void EditPunch(string notes, string img, int type)
        {
            if (!string.IsNullOrEmpty(notes))
            {
                this.UpdateData.punch_notes = notes;
            }

            if (!string.IsNullOrEmpty(img))
            {
                this.UpdateData.punch_img = img;
            }

           
                this.UpdateData.punch_type_id = type;
            
            DB.SaveChanges();
        }
    }
}





