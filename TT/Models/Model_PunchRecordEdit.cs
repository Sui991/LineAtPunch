using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TT.EFModels;
namespace TT.Models
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
        public void GetPunchData(string employeeID,int id)
        {
            this.UpdateData = DB.PunchRecord_Table.Where(x => x.A_ID == employeeID && x.id==id).FirstOrDefault();
        }
        public void EditPunch(string notes,byte[] img ,string type)
        {
            if (notes != null)
            {
                this.UpdateData.notes = notes;
            }
            
            if (img != null)
            {
                this.UpdateData.img = img;
            }

            if (type != null)
            {
                this.UpdateData.type = type;
            }
            DB.SaveChanges();
        }
       
        
         
        }
   
        }



   

