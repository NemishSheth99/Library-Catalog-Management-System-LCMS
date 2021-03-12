using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Database;

namespace LCMS.DAL.Repository.Interface
{
    public interface ITransactionHistoryRepository
    {
        List<TransactionHistory> SearchTransactionHistories(string search);
        List<TransactionHistory> GetTransactionHistories(List<TransactionHistory> transactionhistoryList, int pageNo);
        

        List<TransactionHistory> GetUserTransactionHistories(int userId);
        List<TransactionHistory> SearchUserTransactionHistories(List<TransactionHistory> transactionhistoryList, string search);

        string Create(TransactionHistory transactionHistory);
        int GetCount(int userId,string search);
        int UserTransactionCount(int userId);
    }
}
