using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LCMS.BAL.Interface;
using LCMS.Models;

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

        // GET: api/BookPlaceAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BookPlaceAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BookPlaceAPI
        public IHttpActionResult Post(BookPlace bookPlace)
        {
            int bookId = _bookPlaceManager.Create(bookPlace);
            TransactionHistory obj = new TransactionHistory();
            obj.BookId = bookId;
            obj.TransactionType = "ADD";
            obj.ApplicationUserId = 1;
            obj.TrasactionDate = DateTime.Now;
            return Ok(_transactionHistoryManager.Create(obj));
        }

        // PUT: api/BookPlaceAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BookPlaceAPI/5
        public void Delete(int id)
        {
        }
    }
}
