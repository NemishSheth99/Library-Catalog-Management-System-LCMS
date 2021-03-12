using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.TransactionHistory;

namespace LCMS.BAL.Interface
{
    public interface ITransactionHistoryManager
    {
        TransactionHistoryResponse GetTransactionHistories(int pageNo,string search);
        TransactionHistoryResponse GetTransactionHistoriesByUserId(int userId,int pageNo, string search);
        string Create(AddTransactionHistory addTransactionHistory);
        int UserTransactionCount(int userId);
    }
}
