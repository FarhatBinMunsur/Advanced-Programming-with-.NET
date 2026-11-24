using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Guard
{
    public class SessionAuthorizer : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.Session.GetString("Email");
            if (string.IsNullOrEmpty(user))
            {
                context.HttpContext.Response.StatusCode = 401; // Unauthorized
                context.Result = new Microsoft.AspNetCore.Mvc.JsonResult(new { message = "Unauthorized access" });
            }
        }
    }
}