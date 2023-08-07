using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace TT.Models
{
    public class Model_PasswordReset
    {
       

        public void SaveResetTokenToDatabase(string email, string resetToken)
        {
            // 將token+用戶電子信箱存到資料庫
        }

        public void SendResetLinkEmail(string emails, string resetToken)
        {
            // 創建連結
            string resetLink = $"https://localhost:44320/api/ForgetPassword/ForgotPassword?email={emails}&token={resetToken}";
          
            var mail = new MailMessage();

            // 收件人 Email 地址
            foreach (var email in emails.Split(','))
            {
                mail.To.Add(email);
            }
            // 主旨
            mail.Subject = "重置密碼";
            // 內文
            mail.Body = $"請點擊以下連結來重置你的密碼：\n{resetLink}";
            // 內文是否為 HTML
            mail.IsBodyHtml = true;
            // 優先權
            mail.Priority = MailPriority.Normal;

            // 發信來源,最好與你發送信箱相同,否則容易被其他的信箱判定為垃圾郵件.
            mail.From = new MailAddress("a23512164a@gmail.com", "打卡系統");

            // 附加檔案,如果沒有附加檔案不用這一趴
            //foreach (var path in paths.Split(','))
            //{
            //    Attachment attachment = new Attachment(path);
            //    mail.Attachments.Add(attachment);
            //}

            // Gmail 的 SMTP 設定
            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new System.Net.NetworkCredential("a23512164a@gmail.com", "bpgbhbpalgzsenum"),
                EnableSsl = true
            };

            // 投遞出去
            smtp.Send(mail);

            mail.Dispose();
        }

        public void UpdateUserPassword(string email, string newPassword)
        {
            // 根據電子信箱找到用戶，並更改密碼
        }
    }
}
