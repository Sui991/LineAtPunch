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
        public IHttpActionResult ForgotPassword(string email)
        {
            // 在这里处理密码重置请求
            // 首先，验证用户提供的电子邮件是否有效，并找到匹配的用户帐户

            // 生成唯一的重置令牌
            Models.Model_PasswordReset model_PasswordReset = new Models.Model_PasswordReset(); 

            string resetToken = Guid.NewGuid().ToString();
            

            // 将令牌与用户的电子邮件地址关联，存储在数据库或缓存中，以便后续验证使用
            model_PasswordReset.SaveResetTokenToDatabase(email, resetToken);

            // 发送包含重置令牌的链接到用户的电子邮件
            model_PasswordReset.SendResetLinkEmail(email, resetToken);

            return Ok("重置連結已發送到您的電子郵件賬戶，請盡快按照指示進行密碼重置。");
        }

        [HttpPost]
        public IHttpActionResult ResetPassword(string email, string resetToken, string newPassword, Models.Model_PasswordReset model_PasswordReset) 

        {
            // 在这里处理密码重置请求
            // 首先，验证重置令牌的有效性，并找到匹配的用户帐户

            // 更新用户的密码为新密码
           

            model_PasswordReset.UpdateUserPassword(email, newPassword);

            return Ok("密碼已重置為"+ newPassword);
        }

       

        
        
    }
}