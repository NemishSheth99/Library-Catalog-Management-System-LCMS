using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LCMS.BAL.Interface;
using LCMS.Models.TransactionHistory;

namespace LCMS.WebAPI.Controllers
{
    public class TransactionHistoryAPIController : ApiController
    {
        private readonly ITransactionHistoryManager _transactionHistoryManager;

        public TransactionHistoryAPIController(ITransactionHistoryManager transactionHistoryManager)
        {
            _transactionHistoryManager = transactionHistoryManager;
        }

        // GET: api/TransactionHistoryAPI
        [Route("api/TransactionHistoryAPI/GetTransactionHistories")]
        [HttpGet]
        public IHttpActionResult GetTransactionHistories(int pageNo,string search)
        {
            return Ok(_transactionHistoryManager.GetTransactionHistories(pageNo,search));
        }

        // GET: api/TransactionHistoryAPI
        [Route("api/TransactionHistoryAPI/GetUserTransactionHistories")]
        [HttpGet]
        public IHttpActionResult GetUserTransactionHistories(int id,int pageNo,string search)
        {
            return Ok(_transactionHistoryManager.GetTransactionHistoriesByUserId(id,pageNo,search));
        }

        [Route("api/TransactionHistoryAPI/AddTransactionhistory")]
        [HttpPost]
        public IHttpActionResult AddTransactionhistory(AddTransactionHistory addTransactionHistory)
        {
            return Ok(_transactionHistoryManager.Create(addTransactionHistory));
        }
    }
}
