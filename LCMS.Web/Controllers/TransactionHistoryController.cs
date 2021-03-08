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


        //public ActionResult TransactionHistoryIndex()
        //{
        //    List<TransactionHistoryDetail> historyList = _transactionHistoryServiceProxy.GetTransactionHistories();
        //    return View(historyList);
        //}

        public ActionResult TransactionHistoryIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTransactionHistoryIndex(int pageNo,string searchISBN)
        {
            TransactionHistoryResponse historyResponse = _transactionHistoryServiceProxy.GetTransactionHistories(pageNo,searchISBN);
            return Json(historyResponse, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserTransactionHistoryIndex()
        {
            List<TransactionHistoryDetail> historyList = new List<TransactionHistoryDetail>();
            if (Session["auid"] != null)
            {
                historyList = _transactionHistoryServiceProxy.GetUserTransactionHistories(Convert.ToInt32(Session["auid"]));
            }
            return View(historyList);
        }
    }
}