using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LCMS.ServiceProxy.BookCatalog;
using LCMS.ServiceProxy.Author;
using LCMS.Models.BookCatalog;
using LCMS.Models.Author;
using LCMS.Web.Models;
using AutoMapper;
using System.IO;

namespace LCMS.Web.Controllers
{
    public class BookCatalogController : Controller
    {
        private readonly IBookCatalogServiceProxy _bookCatalogServiceProxy;
        private readonly IAuthorServiceProxy _authorServiceProxy;

        public BookCatalogController(IBookCatalogServiceProxy bookCatalogServiceProxy,IAuthorServiceProxy authorServiceProxy)
        {
            _bookCatalogServiceProxy = bookCatalogServiceProxy;
            _authorServiceProxy = authorServiceProxy;
        }

        #region Librarian
        // GET: BookCatalog
        public ActionResult BookCatalogIndex()
        {
            List<BookCatalogDetail> bookCatalogDetailList = _bookCatalogServiceProxy.GetBookCatalogs();
            return View(bookCatalogDetailList);
        }

        public ActionResult Create()
        {
            return View(new BookCatalogCreateVM());
        }

        public ActionResult CreateOrEditBookCatalog(BookCatalogCreateVM bookcatalogVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<BookCatalogCreateVM, AddBookCatalog>());
                    var mapper = new Mapper(config);
                    AddBookCatalog bookCatalog = mapper.Map<AddBookCatalog>(bookcatalogVM);
                    bookCatalog.IsDeleted = false;
                    if (bookcatalogVM.CoverImage != null)
                    {
                        string coverImage = Path.GetFileName(bookcatalogVM.CoverImage.FileName);
                        bookcatalogVM.CoverImage.SaveAs(Server.MapPath("~/BookCoverImages/" + coverImage));
                        bookCatalog.CoverImage = coverImage;
                        bookCatalog.ImageContentType = bookcatalogVM.CoverImage.ContentType;
                    }
                    //else
                    //{
                    //    product.SmallImage = TempData["SmallImage"].ToString();
                    //}

                    int id = 0;
                    if (bookcatalogVM.Id == 0)
                    {
                        bookCatalog.CreatedDate = DateTime.Now;
                        bookCatalog.UpdatedDate = null;
                        id = _bookCatalogServiceProxy.Create(bookCatalog);  
                        if(id>0)
                        {
                            int cnt = 0;
                            for(int i=0;i<bookcatalogVM.Author.Count;i++)
                            {
                                AuthorDetail authorDetail = new AuthorDetail();
                                authorDetail.BookCatalogId = id;
                                authorDetail.Name = bookcatalogVM.Author[i];
                                string result = _authorServiceProxy.Create(authorDetail);
                                if(result=="Success")
                                    cnt++;
                            }
                            if (bookcatalogVM.Author.Count == cnt)
                                return RedirectToAction("BookCatalogIndex");
                        }
                    }
                    //else
                    //{
                    //    bookCatalog.CreatedDate = null;
                    //    bookCatalog.UpdatedDate = DateTime.Now;
                    //    id = _bookCatalogServiceProxy.Update(bookPlace);
                    //    transactionStatus = "UPDATE";
                    //}
                    
                }
                return RedirectToAction("ErrorPage");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorPage");
            }

        }

        public ActionResult Delete(int id)
        {
            string result;
            result = _bookCatalogServiceProxy.Delete(id);
            if (result == "Success")
            {
                string rs = _authorServiceProxy.Delete(id);
                if (rs == "Success")
                    return RedirectToAction("BookCatalogIndex");
            }
            return RedirectToAction("ErrorPage");
        }

        #endregion

        #region Other users

        public ActionResult ShowCatalog()
        {
            List<BookCatalogDetail> bookCatalogDetailList = _bookCatalogServiceProxy.GetBookCatalogs();
            return View(bookCatalogDetailList);
        }

        public ActionResult ShowCatalogDetail(int id)
        {
            BookCatalogDetail bookCatalogDetail = _bookCatalogServiceProxy.GetBookCatalog(id);
            return View(bookCatalogDetail);
        }

        #endregion
    }
}