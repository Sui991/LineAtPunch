using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace TT.Models
{
    public class JwtAuthActionFilter : ActionFilterAttribute
    {
        private TokenManager _tokenManager;
       
        public JwtAuthActionFilter()
        {
            _tokenManager = new TokenManager();
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var user = _tokenManager.GetUser();

            var employeeId = user?.auth_employeeId;
            HttpContext.Current.Items["EmployeeId"] = employeeId;
            //若user不為空值 賦予httpContext員工編號及成員類型 給api使用

            var accountType = user?.auth_accountType;
            HttpContext.Current.Items["AccountType"] = accountType;

            if (user == null)
            {
                setErrorResponse(actionContext, "驗證錯誤");
            }

            base.OnActionExecuting(actionContext);
        }

        private static void setErrorResponse(HttpActionContext actionContext, string message)
        {
            var response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, message);
            actionContext.Response = response;
        }
    }
}