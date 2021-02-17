using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models;

namespace LCMS.BAL.Interface
{
    public interface ITransactionHistoryManager
    {
        List<TransactionHistory> GetTransactionHistoriesByUserId(int userId);
        List<TransactionHistory> GetTransactionHistoriesByDate(DateTime dt);
        List<TransactionHistory> GetTransactionHistoriesByBook(int bookPlaceId);
        string Create(TransactionHistory transactionHistory);
    }
}
