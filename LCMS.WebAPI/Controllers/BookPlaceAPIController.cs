using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LCMS.BAL.Interface;
using LCMS.Models.BookPlace;

namespace LCMS.WebAPI.Controllers
{
    public class BookPlaceAPIController : ApiController
    {
        private readonly IBookPlaceManager _bookPlaceManager;
        private readonly ITransactionHistoryManager _transactionHistoryManager;

        public BookPlaceAPIController(IBookPlaceManager bookPlaceManager, ITransactionHistoryManager transactionHistoryManager)
        {
            _bookPlaceManager = bookPlaceManager;
            _transactionHistoryManager = transactionHistoryManager;
        }

        [Route("api/BookPlaceAPI/GetBooks")]
        [HttpGet]
        public IHttpActionResult GetBooks(int bookCatalogId)
        {
            return Ok(_bookPlaceManager.GetBookPlacesByCatalog(bookCatalogId));
        }

        [Route("api/BookPlaceAPI/GetAvailableBooks")]
        [HttpGet]
        public IHttpActionResult GetAvailableBooks(int bookCatalogId)
        {
            return Ok(_bookPlaceManager.GetAvailableBooksByCatalog(bookCatalogId));
        }

        [Route("api/BookPlaceAPI/AddBookPlace")]
        [HttpPost]
        public IHttpActionResult AddBookPlace(AddBookPlace bookPlace)
        {
            int x = _bookPlaceManager.Create(bookPlace);
            return Ok(x);
        }

        [Route("api/BookPlaceAPI/GetUserCheckoutBooks")]
        [HttpGet]
        public IHttpActionResult GetUserCheckoutBooks(int userId)
        {
            return Ok(_bookPlaceManager.GetUserCheckOutBooks(userId));
        }

        [Route("api/BookPlaceAPI/CheckOutBookPlace")]
        [HttpPut]
        public IHttpActionResult CheckOutBookPlace(BookPlaceCheckOut bookPlaceCheckOut)
        {
            return Ok(_bookPlaceManager.CheckOutBook(bookPlaceCheckOut.Id, bookPlaceCheckOut.UserId));
        }

        [Route("api/BookPlaceAPI/CheckInBookPlace/{id}")]
        [HttpPut]
        public IHttpActionResult CheckInBookPlace(int id)
        {
            return Ok(_bookPlaceManager.CheckInBook(id));
        }

        // POST: api/BookPlaceAPI
        //public IHttpActionResult Post(BookPlace bookPlace)
        //{
        //    int bookId = _bookPlaceManager.Create(bookPlace);
        //    TransactionHistory obj = new TransactionHistory();
        //    obj.BookId = bookId;
        //    obj.TransactionType = "ADD";
        //    obj.ApplicationUserId = 1;
        //    obj.TrasactionDate = DateTime.Now;
        //    return Ok(_transactionHistoryManager.Create(obj));
        //}


    }
}
