using System;
using System.Net;
using System.Net.Mail;
using System.Web.Http;
namespace TT.Controllers
{
    public class ForgetPasswordController : ApiController
    {
        // GET: ForgetPassword
        [HttpGet]
        public IHttpActionResult ForgotPassword(string strEmail)
        {
            // 處理忘記密碼請求
            // 驗證用戶提供的電子信箱是否有效，並找到匹配的用戶帳戶

            // 產生唯一的驗證token
            Models.Model_PasswordReset model_PasswordReset = new Models.Model_PasswordReset(); 

            string resetToken = Guid.NewGuid().ToString();
            

            // 將token與用戶的電子信箱關聯，並儲存在資料庫
            model_PasswordReset.SaveResetTokenToDatabase(strEmail, resetToken);

            // 發送包含重置token的連結到用戶的電子信箱
            model_PasswordReset.SendResetLinkEmail(strEmail, resetToken);

            return Ok("重置連結已發送到您的電子信箱帳戶，請盡快按照指示進行密碼重置。");
        }

        [HttpPost]
        public IHttpActionResult ResetPassword(string strEmail, string resetToken, string strNewPassword, Models.Model_PasswordReset model_PasswordReset) 

        {
            // 處理密碼重置請求

            // 首先，驗證token的有效性，並找到匹配的用戶帳戶

            // 更新用戶的密碼為新密碼
           

            model_PasswordReset.UpdateUserPassword(strEmail, strNewPassword);

            return Ok("密碼已重置為"+ strNewPassword);
        }

       

        
        
    }
}