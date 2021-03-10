using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LCMS.ServiceProxy.TransactionHistory;
using LCMS.Models.TransactionHistory;

namespace LCMS.Web.Controllers
{
    public class TransactionHistoryController : Controller
    {
        private readonly ITransactionHistoryServiceProxy _transactionHistoryServiceProxy;

        public TransactionHistoryController(ITransactionHistoryServiceProxy transactionHistoryServiceProxy)
        {
            _transactionHistoryServiceProxy = transactionHistoryServiceProxy;
        }
        

        public ActionResult TransactionHistoryIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTransactionHistoryIndex(int pageNo,string search)
        {
            TransactionHistoryResponse historyResponse = _transactionHistoryServiceProxy.GetTransactionHistories(pageNo,search);
            return Json(historyResponse, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserTransactionHistoryIndex()
        {
            return View();            
        }

        [HttpGet]
        public ActionResult GetUserTransactionHistoryIndex(int pageNo, string searchISBN)
        {
            TransactionHistoryResponse historyResponse = new TransactionHistoryResponse();
            if (Session["auid"] != null)
            {
                historyResponse= _transactionHistoryServiceProxy.GetUserTransactionHistories(Convert.ToInt32(Session["auid"]), pageNo, searchISBN);
            }
            return Json(historyResponse, JsonRequestBehavior.AllowGet);
        }
    }
}