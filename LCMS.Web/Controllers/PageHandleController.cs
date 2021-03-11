using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LCMS.Web.Controllers
{
    public class PageHandleController : Controller
    {
        // GET: PageHandle
        public ActionResult UnAuthorized()
        {
            return View();
        }
    }
}