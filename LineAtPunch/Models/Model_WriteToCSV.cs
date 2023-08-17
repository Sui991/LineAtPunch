using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using LineAtPunch.EFModels;
namespace LineAtPunch.Models
{
    public class Model_WriteToCSV
    {
        private LineAtDBEntities DB = new LineAtDBEntities();


        public void WriteToCSV(MemoryStream memoryStream)
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
            var NewTable = from p in DB.vw_PunchRecord
                           join a in DB.AccountData_Table on p.vw_employee equals a.account_employee_id
                           select new
                           {
                               Name = a.account_name,
                               Department = a.account_department,
                               EmpolyeeID = a.account_employee_id,
                               Date = p.vw_datetime,
                               Address = p.vw_addr,
                               Img = p.vw_img,
                               Notes = p.vw_notes,
                               Types = p.vw_type
                           };

            //foreach (var item in NewTable)
            //   {
            //       LogList=($"{item.Department},{item.EmpolyeeID},{item.Name},{item.Date}," +
            //            $"{item.Address},{item.Img},{item.Notes}");
            //    }

            using (var writer = new StreamWriter(memoryStream, Encoding.UTF8))
            {
                writer.WriteLine($"姓名, 部門, 員工編號, 打卡時間, 打卡地點, 打卡類型, 照片, 備註");
                foreach (var item in NewTable)
                {

                    writer.WriteLine($"{item.Name},{item.Department},{item.EmpolyeeID},{item.Date}," +
                            $"{item.Address},{item.Types},{item.Img},{item.Notes}");
                }
            }
        }

    }
}