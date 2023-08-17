using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LineAtPunch.EFModels;

namespace LineAtPunch.Models
{
    public class Model_PunchRecordSearch
    {
        private LineAtDBEntities DB = new LineAtDBEntities();

        public List<vw_PunchRecord> Log_List { get; set; }
        
        public Model_PunchRecordSearch()
        {
            

            
        }

    
      public string GetAllRecord(string strEmployeeID)
        {
            try
            {
                this.Log_List = DB.vw_PunchRecord.Where(a => a.vw_employee == strEmployeeID).ToList();
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            return "查詢成功";

        }
        public string Record_Search(int id )
        {

            try
            {
                this.Log_List = DB.vw_PunchRecord.Where(a => a.id == id).ToList();
            }
            catch(Exception e )
            {
                return e.ToString();
            }

            return "查詢成功";
        }
    }
}