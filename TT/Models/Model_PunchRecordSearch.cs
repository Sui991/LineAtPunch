using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TT.EFModels;

namespace TT.Models
{
    public class Model_PunchRecordSearch
    {
        private LineAtDBEntities DB = new LineAtDBEntities();

        public List<PunchRecord_Table> Log_List { get; set; }

        public Model_PunchRecordSearch()
        {
            
            this.Log_List = new List<PunchRecord_Table>();

            
        }

        public string init()
        {


            return "";
        }
      public string GetAllRecord(string employeeID)
        {
            try
            {
                this.Log_List = DB.PunchRecord_Table.Where(a => a.A_ID == employeeID).ToList();
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
                this.Log_List = DB.PunchRecord_Table.Where(a => a.id == id).ToList();
            }
            catch(Exception e )
            {
                return e.ToString();
            }

            return "查詢成功";
        }
    }
}