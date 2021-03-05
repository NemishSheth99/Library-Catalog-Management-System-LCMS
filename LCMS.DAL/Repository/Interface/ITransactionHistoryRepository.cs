﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Database;

namespace LCMS.DAL.Repository.Interface
{
    public interface ITransactionHistoryRepository
    {
        List<TransactionHistory> GetTransactionHistories();
        List<TransactionHistory> GetTransactionHistoriesByUserId(int userId);
        //List<TransactionHistory> GetTransactionHistoriesByDate(DateTime dt);
        //List<TransactionHistory> GetTransactionHistoriesByBook(int bookPlaceId);
        string Create(TransactionHistory transactionHistory);
    }
}
