using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LCMS.BAL.Interface;

namespace LCMS.WebAPI.Controllers
{
    public class BookPlaceAPIController : ApiController
    {
        private readonly IBookPlaceManager _bookPlaceManager;
        private readonly ITransactionHistoryManager _transactionHistoryManager;

        public BookPlaceAPIController(IBookPlaceManager bookPlaceManager,ITransactionHistoryManager transactionHistoryManager)
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
