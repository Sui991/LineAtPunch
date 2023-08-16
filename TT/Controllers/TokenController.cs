using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TT.Models;
using TT.EFModels;

namespace TT.Controllers
{
    [RoutePrefix("api/token")]
    public class TokenController : ApiController
    {
       
        private TokenManager _tokenManager;
        public TokenController()
        {
            _tokenManager = new TokenManager();
        }

        //紀錄 Refresh Token，需紀錄在資料庫
        private static Dictionary<string,User > refreshTokens =
            new Dictionary<string,User>();

        //登入
        [Route("signIn")]
        [HttpPost]
       
        public Token SignIn(SignInViewModel signInViewModel)
        {
            int c_id = 0;
            //模擬從資料庫取得資料
            Model_Login model = new Model_Login();
            var Login_result = model.Login(signInViewModel);
            if (Login_result == false)
            {
throw new Exception("登入失敗，帳號或密碼錯誤");

            }
            var user = new User {Id=c_id+=1,UserEmail=model.employee.account_email,UserName=model.employee.account_name,Identity=Identity.User,auth_employeeId=model.auth_employeeid };
            //產生 Token
            var token = _tokenManager.Create(user);
            //需存入資料庫
            refreshTokens.Add(token.refresh_token, user);
            return token;
        }

        //換取新 Token
        [HttpPost]
        [Route("refresh")]
        public Token Refresh([FromBody] string refreshToken)
        {
            //檢查 Refresh Token 是否正確
            if (!refreshTokens.ContainsKey(refreshToken))
            {
                throw new Exception("查無此 Refresh Token");
            }
            //需查詢資料庫
            var user = refreshTokens[refreshToken];
            //產生一組新的 Token 和 Refresh Token
            var token = _tokenManager.Create(user);
            //刪除舊的
            refreshTokens.Remove(refreshToken);
            //存入新的
            refreshTokens.Add(token.refresh_token, user);
            return token;
        }

        //測試是否通過驗證
        //[HttpPost]
        //[Route("isAuthenticated")]
        //public bool IsAuthenticated()
        //{
        //    var user = _tokenManager.GetUser();
        //    if (user == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}
