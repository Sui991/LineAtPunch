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
 PunchRecord_Table punch { get; set; }
        public Model_PunchRecordCreate()
        {
        }
        public override string ToString()
        {

            return String.Format("address: {0},notes:: {1},img:{2},A_ID:{3},type:{4},id:{5},datetime:{6}",punch.address,punch.notes,punch.img,punch.A_ID,punch.type,punch.id,punch.datetime);
        }

        public void CreatePunch(PunchRecord_Table punchRecord_Table)
        {
            
            punchRecord_Table.datetime = DateTime.Now;
            punch = punchRecord_Table;
            DB.PunchRecord_Table.Add(punch);
            DB.SaveChanges();
        }
       
        
         
        }
   
        }



   

