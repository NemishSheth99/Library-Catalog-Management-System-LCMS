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
        //List<TransactionHistory> GetTransactionHistories();
        List<TransactionHistory> GetTransactionHistories(int pageNo,string search);

        //List<TransactionHistory> GetTransactionHistoriesByUserId(int userId);
        List<TransactionHistory> GetTransactionHistoriesByUserId(int userId, int pageNo);
        string Create(TransactionHistory transactionHistory);
        int GetTotalCount();
    }
}
