using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Database;
using LCMS.DAL.Repository.Interface;

namespace LCMS.DAL.Repository.Class
{
    public class TransactionHistoryRepository : ITransactionHistoryRepository
    {
        private readonly Database.LCMSDBEntities _dbContext;

        public TransactionHistoryRepository()
        {
            _dbContext = new Database.LCMSDBEntities();
        }

        public List<TransactionHistory> GetTransactionHistories()
        {
            List<TransactionHistory> transactionhistoryList = _dbContext.TransactionHistories.ToList();
            //List<TransactionHistory> lst = new List<TransactionHistory>();

            //if (list != null)
            //{
            //    foreach (var items in list)
            //    {
            //        var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.TransactionHistory, TransactionHistory>());
            //        var mapper = new Mapper(config);
            //        TransactionHistory obj = mapper.Map<TransactionHistory>(items);
            //        lst.Add(obj);
            //    }
            //}
            return transactionhistoryList;
        }

        public List<TransactionHistory> GetTransactionHistoriesByUserId(int userId)
        {
            List<TransactionHistory> transactionhistoryList = _dbContext.TransactionHistories.Where(x => x.ApplicationUserId == userId).ToList();           
            return transactionhistoryList;
        }

        //public List<TransactionHistory> GetTransactionHistoriesByDate(DateTime dt)
        //{
        //    var list = _dbContext.TransactionHistories.Where(x => x.TrasactionDate == dt).ToList();
        //    List<TransactionHistory> lst = new List<TransactionHistory>();

        //    if (list != null)
        //    {
        //        foreach (var items in list)
        //        {
        //            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.TransactionHistory, TransactionHistory>());
        //            var mapper = new Mapper(config);
        //            TransactionHistory obj = mapper.Map<TransactionHistory>(items);
        //            lst.Add(obj);
        //        }
        //    }
        //    return lst;
        //}

        //public List<TransactionHistory> GetTransactionHistoriesByBook(int bookPlaceId)
        //{
        //    var list = _dbContext.TransactionHistories.Where(x => x.BookId == bookPlaceId).ToList();
        //    List<TransactionHistory> lst = new List<TransactionHistory>();

        //    if (list != null)
        //    {
        //        foreach (var items in list)
        //        {
        //            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.TransactionHistory, TransactionHistory>());
        //            var mapper = new Mapper(config);
        //            TransactionHistory obj = mapper.Map<TransactionHistory>(items);
        //            lst.Add(obj);
        //        }
        //    }
        //    return lst;
        //}

        //public string Create(TransactionHistory transactionHistory)
        //{
        //    try
        //    {
        //        if (transactionHistory != null)
        //        {
        //            var config = new MapperConfiguration(cfg => cfg.CreateMap<TransactionHistory, Database.TransactionHistory>());
        //            var mapper = new Mapper(config);
        //            Database.TransactionHistory obj = mapper.Map<Database.TransactionHistory>(transactionHistory);
        //            _dbContext.TransactionHistories.Add(obj);
        //            _dbContext.SaveChanges();
        //            return "Success";
        //        }
        //        return "Fail";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}
    }
}
