using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LCMS.ServiceProxy.BookPlace;
using LCMS.Models.BookPlace;

namespace LCMS.Web.Controllers
{
    public class BookPlaceController : Controller
    {
        private readonly IBookPlaceServiceProxy _bookPlaceServiceProxy;

        public BookPlaceController(IBookPlaceServiceProxy bookPlaceServiceProxy)
        {
            _bookPlaceServiceProxy = bookPlaceServiceProxy;
        }
        // GET: BookPlace
        public ActionResult BookPlaceIndex(int id)
        {
            List<BookPlaceDetail> listBookPlaceDetail = _bookPlaceServiceProxy.GetBookPlacesByCatalog(id);
            return View(listBookPlaceDetail);
        }
    }
}