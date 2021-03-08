using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Database;
using LCMS.DAL.Repository.Interface;

namespace LCMS.DAL.Repository.Class
{
    public class TransactionHistoryRepository : ITransactionHistoryRepository
    {
        private readonly Database.LCMSDBEntities _dbContext;

        public TransactionHistoryRepository()
        {
            _dbContext = new Database.LCMSDBEntities();
        }
        
        //public List<TransactionHistory> GetTransactionHistories()
        //{
        //    List<TransactionHistory> transactionhistoryList = _dbContext.TransactionHistories.ToList();
        //    return transactionhistoryList;
        //}

        public List<TransactionHistory> GetTransactionHistories(int pageNo,string search)
        {
            int NoOfRecordsPerPage = 15;
            int NoOfRecordsToSkip = (pageNo - 1) * NoOfRecordsPerPage;
            List<TransactionHistory> transactionhistoryList = new List<TransactionHistory>();
            if (search!=null)
                transactionhistoryList = _dbContext.TransactionHistories.Where(x=>x.BookPlace.BookCatalog.ISBN.Equals(search)).OrderByDescending(x=>x.TrasactionDate).Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
            else
                transactionhistoryList= _dbContext.TransactionHistories.OrderByDescending(x => x.TrasactionDate).Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
            return transactionhistoryList;
        }        

        public List<TransactionHistory> GetTransactionHistoriesByUserId(int userId,int pageNo)
        {
            int NoOfRecordsPerPage = 15;
            int NoOfRecordsToSkip = (pageNo - 1) * NoOfRecordsPerPage;
            List<TransactionHistory> transactionhistoryList = _dbContext.TransactionHistories.Where(x => x.ApplicationUserId == userId).OrderByDescending(x => x.TrasactionDate).Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
            return transactionhistoryList;
        }        

        public string Create(TransactionHistory transactionHistory)
        {
            if (transactionHistory != null)
            {                
                _dbContext.TransactionHistories.Add(transactionHistory);
                _dbContext.SaveChanges();
                return "Success";
            }
            return "Fail";
        }

        public int GetTotalCount()
        {
            return _dbContext.TransactionHistories.Count();
        }
    }
}
