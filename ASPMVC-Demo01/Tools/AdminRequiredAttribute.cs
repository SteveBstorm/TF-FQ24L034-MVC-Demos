using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASPMVC_Demo01.Tools
{
    public class AdminRequiredAttribute : TypeFilterAttribute
    {
        public AdminRequiredAttribute() : base(typeof(AdminRequiredFilter)) { }
    }

    public class AdminRequiredFilter : IAuthorizationFilter
    {
        private readonly SessionManager _sessionManager;
        public AdminRequiredFilter(SessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(!(_sessionManager.CurrentUser is not null && _sessionManager.CurrentUser.IsAdmin))
            {
                context.Result = new RedirectToRouteResult(new { action = "Index", Controller = "Home" });
            }
        }
    }
}
