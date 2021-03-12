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

        //public List<TransactionHistoryDetail> GetTransactionHistories()
        //{
        //    var queryParam = new Dictionary<string, string>();
        //    return GetRequest<List<TransactionHistoryDetail>>("GetTransactionHistories", queryParam);
        //}

        public TransactionHistoryResponse GetTransactionHistories(int pageNo,string search)
        {
            var queryParam = new Dictionary<string, string>
            {
                {"pageNo", pageNo.ToString(CultureInfo.InvariantCulture)},
                {"search", search.ToString(CultureInfo.InvariantCulture)}
            };
            return GetRequest<TransactionHistoryResponse>("GetTransactionHistories", queryParam);
        }

        public TransactionHistoryResponse GetUserTransactionHistories(int id,int pageNo,string search)
        {
            var queryParam = new Dictionary<string, string>
            {
                {"id", id.ToString(CultureInfo.InvariantCulture)},
                {"pageNo", pageNo.ToString(CultureInfo.InvariantCulture)},
                {"search", search.ToString(CultureInfo.InvariantCulture)}
            };
            return GetRequest<TransactionHistoryResponse> ("GetUserTransactionHistories", queryParam);
        }

        public string Create(AddTransactionHistory addTransactionHistory)
        {
            return MakeRequest<string, AddTransactionHistory>("AddTransactionhistory", ServiceRequestType.Post, addTransactionHistory);
        }

        public int UserTransactionCount(int userId)
        {
            var queryParam = new Dictionary<string, string>
            {
                {"userId", userId.ToString(CultureInfo.InvariantCulture)}
            };
            return GetRequest<int>("UserTransactionCount", queryParam);
        }
    }
}
