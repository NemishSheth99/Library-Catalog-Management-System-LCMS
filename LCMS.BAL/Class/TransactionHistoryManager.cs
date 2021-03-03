using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.BAL.Interface;
using LCMS.DAL.Repository.Interface;
using LCMS.DAL.Database;
using LCMS.Models.TransactionHistory;
using LCMS.Models.ApplicationUser;
using LCMS.Models.BookPlace;
using LCMS.Models.BookCatalog;
using AutoMapper;

namespace LCMS.BAL.Class
{
    public class TransactionHistoryManager : ITransactionHistoryManager
    {
        private readonly ITransactionHistoryRepository _transactionHistoryRepository;

        public TransactionHistoryManager(ITransactionHistoryRepository transactionHistoryRepository)
        {
            _transactionHistoryRepository = transactionHistoryRepository;
        }

        public List<TransactionHistoryDetail> GetTransactionHistories()
        {
            List<TransactionHistory> lst = _transactionHistoryRepository.GetTransactionHistories();
            List<TransactionHistoryDetail> transactionHistoryDetailList = new List<TransactionHistoryDetail>();
            if (lst != null)
            {
                foreach (var items in lst)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<TransactionHistory, TransactionHistoryDetail>().ForMember(x => x.ApplicationUser, y => y.Ignore()).ForMember(x => x.BookPlace, y => y.Ignore()));
                    var mapper = new Mapper(config);
                    TransactionHistoryDetail obj = mapper.Map<TransactionHistoryDetail>(items);
                    if(items.ApplicationUser!=null)
                    {
                        var cnfg = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, ApplicationUserDetail>());
                        var mp = new Mapper(cnfg);
                        obj.ApplicationUser = mp.Map<ApplicationUserDetail>(items.ApplicationUser);
                    }
                    if (items.BookPlace != null)
                    {
                        var cnfg = new MapperConfiguration(cfg => cfg.CreateMap<BookPlace, BookPlaceDetail>().ForMember(x => x.BookCatalog, y => y.Ignore()));
                        var mp = new Mapper(cnfg);
                        obj.BookPlace = mp.Map<BookPlaceDetail>(items.BookPlace);
                        if(obj.BookPlace!=null)
                        {
                            var c = new MapperConfiguration(cfg => cfg.CreateMap<BookCatalog, BookCatalogDetail>());
                            var m = new Mapper(c);
                            obj.BookPlace.BookCatalog = m.Map<BookCatalogDetail>(items.BookPlace.BookCatalog);
                        }
                    }
                    transactionHistoryDetailList.Add(obj);
                }
            }
            return transactionHistoryDetailList;
        }

        public List<TransactionHistoryDetail> GetTransactionHistoriesByUserId(int userId)
        {
            List<TransactionHistory> lst = _transactionHistoryRepository.GetTransactionHistoriesByUserId(userId);
            List<TransactionHistoryDetail> transactionHistoryDetailList = new List<TransactionHistoryDetail>();
            if (lst != null)
            {
                foreach (var items in lst)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<TransactionHistory, TransactionHistoryDetail>().ForMember(x => x.ApplicationUser, y => y.Ignore()).ForMember(x => x.BookPlace, y => y.Ignore()));
                    var mapper = new Mapper(config);
                    TransactionHistoryDetail obj = mapper.Map<TransactionHistoryDetail>(items);
                    if (items.ApplicationUser != null)
                    {
                        var cnfg = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, ApplicationUserDetail>());
                        var mp = new Mapper(cnfg);
                        obj.ApplicationUser = mp.Map<ApplicationUserDetail>(items.ApplicationUser);
                    }
                    if (items.BookPlace != null)
                    {
                        var cnfg = new MapperConfiguration(cfg => cfg.CreateMap<BookPlace, BookPlaceDetail>().ForMember(x => x.BookCatalog, y => y.Ignore()));
                        var mp = new Mapper(cnfg);
                        obj.BookPlace = mp.Map<BookPlaceDetail>(items.BookPlace);
                        if (obj.BookPlace != null)
                        {
                            var c = new MapperConfiguration(cfg => cfg.CreateMap<BookCatalog, BookCatalogDetail>());
                            var m = new Mapper(c);
                            obj.BookPlace.BookCatalog = m.Map<BookCatalogDetail>(items.BookPlace.BookCatalog);
                        }
                    }
                    transactionHistoryDetailList.Add(obj);
                }
            }
            return transactionHistoryDetailList;
        }

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
