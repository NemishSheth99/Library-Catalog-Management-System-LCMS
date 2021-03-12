using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.TransactionHistory;

namespace LCMS.ServiceProxy.TransactionHistory
{
    public interface ITransactionHistoryServiceProxy
    {
        TransactionHistoryResponse GetTransactionHistories(int pageNo,string search);
        TransactionHistoryResponse GetUserTransactionHistories(int id,int pageNo,string search);
        string Create(AddTransactionHistory addTransactionHistory);
        int UserTransactionCount(int userId);
    }
}
