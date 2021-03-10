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

        public List<TransactionHistory> SearchTransactionHistories(string search)
        {
            List<TransactionHistory> transactionhistoryList = new List<TransactionHistory>();
            if (search != null)
                transactionhistoryList = _dbContext.TransactionHistories.Where(x => x.BookPlace.BookCatalog.ISBN.Contains(search) || x.ApplicationUser.Name.Contains(search)).ToList();
            else
                transactionhistoryList = _dbContext.TransactionHistories.ToList();
            return transactionhistoryList;
        }

        public List<TransactionHistory> GetTransactionHistories(List<TransactionHistory> transactionhistoryList,int pageNo)
        {
            int NoOfRecordsPerPage = 15;
            int NoOfRecordsToSkip = (pageNo - 1) * NoOfRecordsPerPage; 
            if(transactionhistoryList.Count>0)
                transactionhistoryList= transactionhistoryList.OrderByDescending(x => x.TrasactionDate).Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
            else
                transactionhistoryList= _dbContext.TransactionHistories.OrderByDescending(x => x.TrasactionDate).Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
            return transactionhistoryList;
        }


        public List<TransactionHistory> GetUserTransactionHistories(int userId)
        {
            List<TransactionHistory> transactionhistoryList = new List<TransactionHistory>();
            if (userId != 0)
                transactionhistoryList = _dbContext.TransactionHistories.Where(x => x.ApplicationUserId==userId).ToList();
            return transactionhistoryList;
        }

        public List<TransactionHistory> SearchUserTransactionHistories(List<TransactionHistory> transactionhistoryList, string search)
        {            
            if (search != null)
                transactionhistoryList = transactionhistoryList.Where(x => x.BookPlace.BookCatalog.ISBN.Contains(search)).ToList();
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

        public int GetCount(int userId,string search)
        {
            List<TransactionHistory> transactionHistoryList = _dbContext.TransactionHistories.ToList();
            if (userId != 0)
                transactionHistoryList = transactionHistoryList.Where(x => x.ApplicationUserId == userId).ToList();
            if (search != null)
                transactionHistoryList=transactionHistoryList.Where(x => x.BookPlace.BookCatalog.ISBN.Contains(search) || x.ApplicationUser.Name.Contains(search)).ToList();
            return transactionHistoryList.Count;
        }
    }
}
