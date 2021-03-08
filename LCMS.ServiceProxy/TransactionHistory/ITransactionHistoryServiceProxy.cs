﻿using System;
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
        //List<TransactionHistoryDetail> GetTransactionHistories();
        List<TransactionHistoryDetail> GetUserTransactionHistories(int id);
        string Create(AddTransactionHistory addTransactionHistory);
    }
}
