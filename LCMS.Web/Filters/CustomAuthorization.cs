using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LCMS.Web.Filters
{
    public class CustomAuthorization : AuthorizeAttribute
    {
        private readonly string[] allowedroles;
        public CustomAuthorization(params string[] roles)
        {
            allowedroles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            string userRole = Convert.ToString(httpContext.Session["aurole"]);
            if (!string.IsNullOrEmpty(userRole))
            {
                foreach (var role in allowedroles)
                {
                    if (role == userRole)
                        return true;
                }
            }
            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "PageHandle" },
                    { "action", "UnAuthorized" }
               });
        }
    }
}