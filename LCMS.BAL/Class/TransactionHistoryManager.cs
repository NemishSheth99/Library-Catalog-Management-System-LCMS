﻿using System;
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

        public TransactionHistoryResponse GetTransactionHistories(int pageNo, string search)
        {
            TransactionHistoryResponse thResponse = new TransactionHistoryResponse();
            List<TransactionHistory> list = _transactionHistoryRepository.SearchTransactionHistories(search);
            if (search != null && list.Count == 0)
            {
                return thResponse;
            }
            else
            {
                List<TransactionHistory> lst = _transactionHistoryRepository.GetTransactionHistories(list, pageNo);
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

                    thResponse.TransactionHistoryList = transactionHistoryDetailList;
                    thResponse.Count = _transactionHistoryRepository.GetCount(0,search);
                }
            }
            return thResponse;
        }

        public TransactionHistoryResponse GetTransactionHistoriesByUserId(int userId, int pageNo,string search)
        {
            TransactionHistoryResponse thResponse = new TransactionHistoryResponse();
            List<TransactionHistory> list = _transactionHistoryRepository.GetUserTransactionHistories(userId);
            if (userId != 0 && list.Count == 0)
            {
                return thResponse;
            }
            else
            {
                List<TransactionHistory> searchList = _transactionHistoryRepository.SearchUserTransactionHistories(list,search);
                if (search != null && searchList.Count == 0)
                {
                    return thResponse;
                }
                else
                {
                    List<TransactionHistory> lst = _transactionHistoryRepository.GetTransactionHistories(searchList, pageNo);
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
                        thResponse.TransactionHistoryList = transactionHistoryDetailList;
                        thResponse.Count = _transactionHistoryRepository.GetCount(userId, search);
                    }
                }
            }
            return thResponse;
        }
        
        public string Create(AddTransactionHistory addTransactionHistory)
        {
            TransactionHistory transactionHistory = new TransactionHistory();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddTransactionHistory, TransactionHistory>());
            var mapper = new Mapper(config);
            transactionHistory = mapper.Map<TransactionHistory>(addTransactionHistory);
            return _transactionHistoryRepository.Create(transactionHistory);
        }

        public int UserTransactionCount(int userId)
        {
            return _transactionHistoryRepository.UserTransactionCount(userId);
        }
    }
}
