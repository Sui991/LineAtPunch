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
        public PunchRecord_Table CreatePunchTable { set; get; }

        
        
    //public string CreatePunch()
    //{
    //    PunchRecord_Table newData = new PunchRecord_Table()
    //    {

            
    //    }
    //    return "Hi";
    //}



    }

}
