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
using LCMS.Web.Filters;
using AutoMapper;
using System.IO;

namespace LCMS.Web.Controllers
{
    public class BookCatalogController : Controller
    {
        private readonly IBookCatalogServiceProxy _bookCatalogServiceProxy;
        private readonly IAuthorServiceProxy _authorServiceProxy;

        public BookCatalogController(IBookCatalogServiceProxy bookCatalogServiceProxy, IAuthorServiceProxy authorServiceProxy)
        {
            _bookCatalogServiceProxy = bookCatalogServiceProxy;
            _authorServiceProxy = authorServiceProxy;
        }

        #region Librarian

        [CustomAuthorization("Librarian")]
        public ActionResult BookCatalogIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetBookCatalogIndex(int pageNo, string search)
        {
            BookCatalogResponse catalogResponse = _bookCatalogServiceProxy.GetBookCatalogs(pageNo, search);
            return Json(catalogResponse, JsonRequestBehavior.AllowGet);
        }

        [CustomAuthorization("Librarian")]
        public ActionResult BookCatalogDetails(int id)
        {
            BookCatalogDetail bookCatalogDetail = _bookCatalogServiceProxy.GetBookCatalog(id);
            List<AuthorDetail> authorList = _authorServiceProxy.GetAuthorsByCatalog(id);
            string author = "";
            foreach (var items in authorList)
            {
                author += items.Name;
            }
            if (author != "")
            {
                bookCatalogDetail.Authors = author;
            }
            return View(bookCatalogDetail);
        }

        [CustomAuthorization("Librarian")]
        public ActionResult Create()
        {
            ViewBag.CoverImage = "";
            ViewBag.List = new List<string>();
            return View(new BookCatalogCreateVM());
        }

        [CustomAuthorization("Librarian")]
        public ActionResult Edit(int id)
        {
            BookCatalogCreateVM bookCatalogCreateVM = new BookCatalogCreateVM();
            BookCatalogDetail bookCatalogDetail = _bookCatalogServiceProxy.GetBookCatalog(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookCatalogDetail, BookCatalogCreateVM>().ForMember(x => x.CoverImage, y => y.Ignore()));
            var mapper = new Mapper(config);
            bookCatalogCreateVM = mapper.Map<BookCatalogCreateVM>(bookCatalogDetail);
            if (bookCatalogCreateVM != null)
            {
                ViewBag.CoverImage= bookCatalogDetail.CoverImage;
                TempData["CoverImage"] = bookCatalogDetail.CoverImage;
                List<AuthorDetail> authorList = _authorServiceProxy.GetAuthorsByCatalog(id);
                List<string> author = new List<string>();
                foreach (var items in authorList)
                {
                    author.Add(items.Name);
                }
                if (author != null)
                {
                    bookCatalogCreateVM.Author = author;
                    ViewBag.List = author;
                }
            }
            return View(bookCatalogCreateVM);
        }

        public ActionResult CreateOrEditBookCatalog(BookCatalogCreateVM bookcatalogVM)
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
                else
                {
                    bookCatalog.CoverImage = TempData["CoverImage"].ToString();
                }

                int id = 0;
                if (bookcatalogVM.Id == 0)
                {
                    bookCatalog.CreatedDate = DateTime.Now;
                    bookCatalog.UpdatedDate = null;
                    id = _bookCatalogServiceProxy.Create(bookCatalog);
                    if (id > 0)
                    {
                        int cnt = 0;
                        for (int i = 0; i < bookcatalogVM.Author.Count; i++)
                        {
                            AuthorDetail authorDetail = new AuthorDetail();
                            authorDetail.BookCatalogId = id;
                            authorDetail.Name = bookcatalogVM.Author[i];
                            string result = _authorServiceProxy.Create(authorDetail);
                            if (result == "Success")
                                cnt++;
                        }
                        if (bookcatalogVM.Author.Count == cnt)
                            return RedirectToAction("BookCatalogIndex");
                    }
                }
                else
                {
                    bookCatalog.CreatedDate = null;
                    bookCatalog.UpdatedDate = DateTime.Now;
                    id = _bookCatalogServiceProxy.Update(bookCatalog);
                    if (id > 0)
                    {
                        List<AuthorDetail> authorList = _authorServiceProxy.GetAuthorsByCatalog(id);
                        List<string> oldAuthors = new List<string>();
                        foreach (var items in authorList)
                        {
                            oldAuthors.Add(items.Name);
                        }

                        List<string> newAuthors = new List<string>();
                        for (int i = 0; i < bookcatalogVM.Author.Count; i++)
                        {
                            newAuthors.Add(bookcatalogVM.Author[i]);
                        }

                        IEnumerable<string> addAuthors = newAuthors.Except(oldAuthors);
                        int cnt = 0, c = 0;
                        foreach (var item in addAuthors)
                        {
                            c++;
                            AuthorDetail authorDetail = new AuthorDetail();
                            authorDetail.BookCatalogId = id;
                            authorDetail.Name = item;
                            string result = _authorServiceProxy.Create(authorDetail);
                            if (result == "Success")
                                cnt++;
                        }
                        if (c == cnt)
                        {
                            IEnumerable<string> removeAuthors = oldAuthors.Except(newAuthors);
                            int count = 0, ct = 0;
                            foreach (var item in removeAuthors)
                            {
                                ct++;
                                AuthorDetail authorDetail = new AuthorDetail();
                                authorDetail.BookCatalogId = id;
                                authorDetail.Name = item;
                                string result = _authorServiceProxy.DeleteAuthor(authorDetail);
                                if (result == "Success")
                                    count++;
                            }
                            if (ct == count)
                            {
                                return RedirectToAction("BookCatalogIndex");
                            }
                            else
                            {
                                string r = _bookCatalogServiceProxy.Delete(id);
                                return RedirectToAction("InternalServerError","PageHandle");
                            }
                        }
                    }
                }

            }
            return RedirectToAction("InternalServerError", "PageHandle");
        }

        [CustomAuthorization("Librarian")]
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

        #region Other Users


        [CustomAuthorization("Lawyer", "Specialist")]
        public ActionResult ShowCatalog()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetShowCatalog(int pageNo, string search)
        {
            BookCatalogResponse catalogResponse = _bookCatalogServiceProxy.GetBookCatalogs(pageNo, search);
            return Json(catalogResponse, JsonRequestBehavior.AllowGet);
        }


        [CustomAuthorization("Lawyer", "Specialist")]
        public ActionResult ShowCatalogDetail(int id)
        {
            BookCatalogDetail bookCatalogDetail = _bookCatalogServiceProxy.GetBookCatalog(id);
            List<AuthorDetail> authorList = _authorServiceProxy.GetAuthorsByCatalog(id);
            string author = "";
            foreach (var items in authorList)
            {
                author+=items.Name;
            }
            if (author != "")
            {
                bookCatalogDetail.Authors = author;
            }
            return View(bookCatalogDetail);
        }

        #endregion
    }
}