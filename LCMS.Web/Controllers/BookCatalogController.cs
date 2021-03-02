using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LCMS.ServiceProxy.BookCatalog;
using LCMS.Models.BookCatalog;

namespace LCMS.Web.Controllers
{
    public class BookCatalogController : Controller
    {
        private readonly IBookCatalogServiceProxy _bookCatalogServiceProxy;

        public BookCatalogController(IBookCatalogServiceProxy bookCatalogServiceProxy)
        {
            _bookCatalogServiceProxy = bookCatalogServiceProxy;
        }
            
        // GET: BookCatalog
        public ActionResult BookCatalogIndex()
        {
            List<BookCatalogDetail> bookCatalogDetailList = _bookCatalogServiceProxy.GetBookCatalogs();
            return View(bookCatalogDetailList);
        }
    }
}