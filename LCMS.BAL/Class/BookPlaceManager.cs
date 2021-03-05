using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.BAL.Interface;
using LCMS.DAL.Database;
using LCMS.DAL.Repository.Interface;
using LCMS.Models.BookPlace;
using LCMS.Models.BookCatalog;
using AutoMapper;

namespace LCMS.BAL.Class
{
    public class BookPlaceManager : IBookPlaceManager
    {
        private readonly IBookPlaceRepository _bookPlaceRepository;

        public BookPlaceManager(IBookPlaceRepository bookPlaceRepository)
        {
            _bookPlaceRepository = bookPlaceRepository;
        }

        public List<BookPlaceDetail> GetBookPlacesByCatalog(int catalogId)
        {
            List<BookPlace> bookPlaceList= _bookPlaceRepository.GetBookPlacesByCatalog(catalogId);
            List<BookPlaceDetail> bookPlaceDetailList = new List<BookPlaceDetail>();
            if(bookPlaceList != null)
            {
                foreach(var items in bookPlaceList)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<BookPlace, BookPlaceDetail>().ForMember(x => x.BookCatalog, y => y.Ignore()));
                    var mapper = new Mapper(config);
                    BookPlaceDetail bookPlaceDetail = mapper.Map<BookPlaceDetail>(items);
                    if(items.BookCatalog!=null)
                    {
                        var cnfg = new MapperConfiguration(cfg => cfg.CreateMap<BookCatalog, BookCatalogDetail>());
                        var mp = new Mapper(cnfg);
                        bookPlaceDetail.BookCatalog = mp.Map<BookCatalogDetail>(items.BookCatalog);
                    }
                    bookPlaceDetailList.Add(bookPlaceDetail);
                }
                return bookPlaceDetailList;
            }
            return bookPlaceDetailList;
        }

        public BookPlaceDetail GetBookPlaceById(int id)
        {
            BookPlace bookPlace= _bookPlaceRepository.GetBookPlaceById(id);
            BookPlaceDetail bookPlaceDetail = new BookPlaceDetail();
            if(bookPlace!=null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<BookPlace, BookPlaceDetail>().ForMember(x => x.BookCatalog, y => y.Ignore()));
                var mapper = new Mapper(config);
                bookPlaceDetail = mapper.Map<BookPlaceDetail>(bookPlace);
                if (bookPlace.BookCatalog != null)
                {
                    var cnfg = new MapperConfiguration(cfg => cfg.CreateMap<BookCatalog, BookCatalogDetail>());
                    var mp = new Mapper(cnfg);
                    bookPlaceDetail.BookCatalog = mp.Map<BookCatalogDetail>(bookPlace.BookCatalog);
                }
            }
            return bookPlaceDetail;
        }

        public int Create(AddBookPlace addBookPlace)
        {
            BookPlace bookPlace = new BookPlace();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddBookPlace, BookPlace>());
            var mapper = new Mapper(config);
            bookPlace = mapper.Map<BookPlace>(addBookPlace);
            return _bookPlaceRepository.Create(bookPlace);
        }

        public int Update(AddBookPlace addBookPlace)
        {
            BookPlace bookPlace = new BookPlace();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddBookPlace, BookPlace>());
            var mapper = new Mapper(config);
            bookPlace = mapper.Map<BookPlace>(addBookPlace);
            return _bookPlaceRepository.Update(bookPlace);
        }

        public string Delete(int id)
        {
            return _bookPlaceRepository.Delete(id);
        }

        public List<BookPlaceDetail> GetAvailableBooksByCatalog(int catalogId)
        {
            List<BookPlace> bookPlaceList = _bookPlaceRepository.GetAvailableBooksByCatalog(catalogId);
            List<BookPlaceDetail> bookPlaceDetailList = new List<BookPlaceDetail>();
            if (bookPlaceList != null)
            {
                foreach (var items in bookPlaceList)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<BookPlace, BookPlaceDetail>().ForMember(x => x.BookCatalog, y => y.Ignore()));
                    var mapper = new Mapper(config);
                    BookPlaceDetail bookPlaceDetail = mapper.Map<BookPlaceDetail>(items);
                    if (items.BookCatalog != null)
                    {
                        var cnfg = new MapperConfiguration(cfg => cfg.CreateMap<BookCatalog, BookCatalogDetail>());
                        var mp = new Mapper(cnfg);
                        bookPlaceDetail.BookCatalog = mp.Map<BookCatalogDetail>(items.BookCatalog);
                    }
                    bookPlaceDetailList.Add(bookPlaceDetail);
                }
                return bookPlaceDetailList;
            }
            return bookPlaceDetailList;
        }

        public List<BookPlaceDetail> GetUserCheckOutBooks(int userId)
        {
            List<BookPlace> bookPlaceList = _bookPlaceRepository.GetUserCheckOutBooks(userId);
            List<BookPlaceDetail> bookPlaceDetailList = new List<BookPlaceDetail>();
            if (bookPlaceList != null)
            {
                foreach (var items in bookPlaceList)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<BookPlace, BookPlaceDetail>().ForMember(x => x.BookCatalog, y => y.Ignore()));
                    var mapper = new Mapper(config);
                    BookPlaceDetail bookPlaceDetail = mapper.Map<BookPlaceDetail>(items);
                    if (items.BookCatalog != null)
                    {
                        var cnfg = new MapperConfiguration(cfg => cfg.CreateMap<BookCatalog, BookCatalogDetail>());
                        var mp = new Mapper(cnfg);
                        bookPlaceDetail.BookCatalog = mp.Map<BookCatalogDetail>(items.BookCatalog);
                    }
                    bookPlaceDetailList.Add(bookPlaceDetail);
                }
                return bookPlaceDetailList;
            }
            return bookPlaceDetailList;
        }        

        public string CheckInBook(int id)
        {
            return _bookPlaceRepository.CheckInBook(id);
        }

        public string CheckOutBook(int id, int userId)
        {
            return _bookPlaceRepository.CheckOutBook(id,userId);
        }

        
    }
}
