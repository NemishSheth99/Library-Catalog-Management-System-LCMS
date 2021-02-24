using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.BAL.Interface;
using LCMS.DAL.Repository.Interface;
using LCMS.Models;

namespace LCMS.BAL.Class
{
    public class TransactionHistoryManager : ITransactionHistoryManager
    {
        private readonly ITransactionHistoryRepository _transactionHistoryRepository;

        public TransactionHistoryManager(ITransactionHistoryRepository transactionHistoryRepository)
        {
            _transactionHistoryRepository = transactionHistoryRepository;
        }

        //public List<TransactionHistory> GetTransactionHistoriesByUserId(int userId)
        //{
        //    return _transactionHistoryRepository.GetTransactionHistoriesByUserId(userId);
        //}

        //public List<TransactionHistory> GetTransactionHistoriesByDate(DateTime dt)
        //{
        //    return _transactionHistoryRepository.GetTransactionHistoriesByDate(dt);
        //}

        //public List<TransactionHistory> GetTransactionHistoriesByBook(int bookPlaceId)
        //{
        //    return _transactionHistoryRepository.GetTransactionHistoriesByBook(bookPlaceId);
        //}

        //public string Create(TransactionHistory transactionHistory)
        //{
        //    return _transactionHistoryRepository.Create(transactionHistory);
        //}        
    }
}
