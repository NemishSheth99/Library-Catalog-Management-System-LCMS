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
        List<TransactionHistoryDetail> GetTransactionHistories();
        List<TransactionHistoryDetail> GetTransactionHistoriesByUserId(int userId);
        //List<TransactionHistory> GetTransactionHistoriesByDate(DateTime dt);
        //List<TransactionHistory> GetTransactionHistoriesByBook(int bookPlaceId);
        string Create(AddTransactionHistory addTransactionHistory);
    }
}
