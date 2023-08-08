using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using TT.EFModels;
namespace TT.Models
{
    public class Model_WriteToCSV
    {
        private LineAtDBEntities DB = new LineAtDBEntities();
      
          
        public void WriteToCSV(string FilePath)
        {
            //合併打卡資料表與帳戶資料表成一個新資料表
            //根據員工編號做合併

            //lambda
            //var NewTable = DB.PunchRecord_Table.Join(DB.Account_DataTable,
            //    accEmpolyeeID => accEmpolyeeID.A_ID,
            //    punEmpolyeeID => punEmpolyeeID.Employee_Id,
            //    (p, a) =>
            //    new
            //    {
            //        Name = a.Name,
            //        Department = a.Department,
            //        EmpolyeeID = a.Employee_Id,
            //        Date = p.datetime,
            //        Address = p.address,
            //        Img = p.img,
            //        Notes = p.notes
            //    });

            //LinQ
            var NewTable = from p in DB.PunchRecord_Table
                           join a in DB.Account_DataTable on p.A_ID equals a.Employee_Id
                           select new
                           {
                               Name = a.Name,
                               Department = a.Department,
                               EmpolyeeID = a.Employee_Id,
                               Date = p.datetime,
                               Address = p.address,
                               Img = p.img,
                               Notes = p.notes
                           };

            //foreach (var item in NewTable)
            //   {
            //       LogList=($"{item.Department},{item.EmpolyeeID},{item.Name},{item.Date}," +
            //            $"{item.Address},{item.Img},{item.Notes}");
            //    }

            using (var file = new StreamWriter(FilePath,false,Encoding.UTF8))
                {
                    foreach(var item in NewTable)
                    {
                        file.WriteLine($"{item.Department},{item.EmpolyeeID},{item.Name},{item.Date}," +
                            $"{item.Address},{item.Img},{item.Notes}");
                    }
                }
        }

    }
}