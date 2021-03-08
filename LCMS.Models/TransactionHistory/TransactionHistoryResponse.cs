using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCMS.Models.TransactionHistory
{
    public class TransactionHistoryResponse
    {
        public List<TransactionHistoryDetail> TransactionHistoryList { get; set; }
        public int Count { get; set; }
    }
}
