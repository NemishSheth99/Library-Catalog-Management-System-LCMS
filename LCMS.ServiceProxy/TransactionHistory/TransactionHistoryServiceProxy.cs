using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.TransactionHistory;
using System.Globalization;

namespace LCMS.ServiceProxy.TransactionHistory
{
    public class TransactionHistoryServiceProxy:ServiceProxyBase,ITransactionHistoryServiceProxy
    {
        public TransactionHistoryServiceProxy()
        {
            ServiceUrlPrefix = "api/TransactionHistoryAPI";
        }

        public List<TransactionHistoryDetail> GetTransactionHistories()
        {
            var queryParam = new Dictionary<string, string>();
            return GetRequest<List<TransactionHistoryDetail>>("GetTransactionHistories", queryParam);
        }

        public List<TransactionHistoryDetail> GetUserTransactionHistories(int id)
        {
            var queryParam = new Dictionary<string, string>
            {
                {"id", id.ToString(CultureInfo.InvariantCulture)}
            };
            return GetRequest<List<TransactionHistoryDetail>>("GetUserTransactionHistories", queryParam);
        }
    }
}
