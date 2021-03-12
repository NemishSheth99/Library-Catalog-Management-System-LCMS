using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LCMS.Web.Filters
{
    public class ExceptionHandle : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext exContext)
        {
            if (exContext.ExceptionHandled || exContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }
            Exception e = exContext.Exception;
            exContext.ExceptionHandled = true;
            exContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
               {
                    { "controller", "PageHandle" },
                    { "action", "Error" }
               });
        }
    }
}