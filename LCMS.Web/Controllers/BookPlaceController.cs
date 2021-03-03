using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LCMS.ServiceProxy.BookPlace;
using LCMS.ServiceProxy.TransactionHistory;
using LCMS.Models.BookPlace;
using LCMS.Models.TransactionHistory;
using LCMS.Web.Models;
using AutoMapper;

namespace LCMS.Web.Controllers
{
    public class BookPlaceController : Controller
    {
        private readonly IBookPlaceServiceProxy _bookPlaceServiceProxy;
        private readonly ITransactionHistoryServiceProxy _transactionHistoryServiceProxy;

        public BookPlaceController(IBookPlaceServiceProxy bookPlaceServiceProxy,ITransactionHistoryServiceProxy transactionHistoryServiceProxy)
        {
            _bookPlaceServiceProxy = bookPlaceServiceProxy;
            _transactionHistoryServiceProxy = transactionHistoryServiceProxy;
        }

        #region Librarian
        // GET: BookPlace
        public ActionResult BookPlaceIndex(int id)
        {
            Session["bcid"] = id;            
            List<BookPlaceDetail> listBookPlaceDetail = _bookPlaceServiceProxy.GetBookPlacesByCatalog(id);
            return View(listBookPlaceDetail);
        }

        public ActionResult Create()
        {
            return View(new BookPlaceCreateVM());
        }

        public ActionResult CreateBookPlace(BookPlaceCreateVM bookPlaceVM)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<BookPlaceCreateVM, AddBookPlace>());
                    var mapper = new Mapper(config);
                    AddBookPlace bookPlace = mapper.Map<AddBookPlace>(bookPlaceVM);
                    bookPlace.BookCatalogId = Convert.ToInt32(Session["bcid"]);
                    bookPlace.BorrowedBy = null;
                    bookPlace.BorrowedOn = null;
                    bookPlace.IsDeleted = false;
                    bookPlace.CreatedDate = DateTime.Now;
                    bookPlace.UpdatedDate = null;
                    int id = _bookPlaceServiceProxy.Create(bookPlace);
                    if (id > 0)
                    {
                        AddTransactionHistory transactionHistory = new AddTransactionHistory();
                        transactionHistory.BookId = id;
                        transactionHistory.TransactionType = "ADD";
                        transactionHistory.TrasactionDate = DateTime.Now;
                        transactionHistory.ApplicationUserId = Convert.ToInt32(Session["auid"]);
                        string r = _transactionHistoryServiceProxy.Create(transactionHistory);
                        if (r == "Success")
                            return RedirectToAction("BookPlaceIndex", "BookPlace", new { @id = Convert.ToInt32(Session["bcid"]) });
                        else
                            return RedirectToAction("ErrorPage");
                    }
                }
                return RedirectToAction("ErrorPage");
            }
            catch(Exception ex)
            {
                return RedirectToAction("ErrorPage");
            }
        }

        #endregion

        #region Other User

        public ActionResult ShowBookPlace(int id)
        {
            List<BookPlaceDetail> listBookPlaceDetail = _bookPlaceServiceProxy.GetAvailableBooksByCatalog(id);
            return View(listBookPlaceDetail);
        }

        public ActionResult CheckOutBook(int id)
        {            
            BookPlaceCheckOut bookPlaceCheckOut = new BookPlaceCheckOut();
            bookPlaceCheckOut.Id = id;
            bookPlaceCheckOut.UserId = Convert.ToInt32(Session["auid"]);
            string result = _bookPlaceServiceProxy.CheckOutBookPlace(bookPlaceCheckOut);
            if (result == "Success")
            {
                AddTransactionHistory transactionHistory = new AddTransactionHistory();
                transactionHistory.BookId = id;
                transactionHistory.TransactionType = "CHECK_OUT";
                transactionHistory.TrasactionDate = DateTime.Now;
                transactionHistory.ApplicationUserId = Convert.ToInt32(Session["auid"]);
                string r = _transactionHistoryServiceProxy.Create(transactionHistory);
                if(r=="Success")
                    return RedirectToAction("MyCheckOuts");
                else
                    return RedirectToAction("ErrorPage");
            }
            else
                return RedirectToAction("ErrorPage");
        }

        public ActionResult MyCheckOuts()
        {
            int userId = Convert.ToInt32(Session["auid"]);
            List<BookPlaceDetail> listBookPlaceDetail = _bookPlaceServiceProxy.GetUserCheckoutBooks(userId);
            return View(listBookPlaceDetail);
        }

        public ActionResult CheckInBook(int id)
        {            
            string result = _bookPlaceServiceProxy.CheckInBookPlace(id);
            if (result == "Success")
            {
                AddTransactionHistory transactionHistory = new AddTransactionHistory();
                transactionHistory.BookId = id;
                transactionHistory.TransactionType = "CHECK_IN";
                transactionHistory.TrasactionDate = DateTime.Now;
                transactionHistory.ApplicationUserId = Convert.ToInt32(Session["auid"]);
                string r = _transactionHistoryServiceProxy.Create(transactionHistory);
                if (r == "Success")
                    return RedirectToAction("ShowCatalog","BookCatalog");
                else
                    return RedirectToAction("ErrorPage");
            }
            else
                return RedirectToAction("ErrorPage");
        }

        #endregion
    }
}