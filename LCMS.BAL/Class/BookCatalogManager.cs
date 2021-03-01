using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.BAL.Interface;
using LCMS.DAL.Repository.Interface;
using LCMS.DAL.Database;
using LCMS.Models.BookCatalog;
using AutoMapper;

namespace LCMS.BAL.Class
{
    public class BookCatalogManager : IBookCatalogManager
    {
        private readonly IBookCatalogRepository _bookCatalogRepository;

        public BookCatalogManager(IBookCatalogRepository bookCatalogRepository)
        {
            _bookCatalogRepository = bookCatalogRepository;
        }

        public List<BookCatalogDetail> GetBookCatalogs()
        {
            List<BookCatalog> bookCataloglist = _bookCatalogRepository.GetBookCatalogs();
            List<BookCatalogDetail> bookCatalogDetailList = new List<BookCatalogDetail>();
            if (bookCataloglist != null)
            {
                foreach (var items in bookCataloglist)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<BookCatalog, BookCatalogDetail>());
                    var mapper = new Mapper(config);
                    BookCatalogDetail bookCatalogDetail = mapper.Map<BookCatalogDetail>(items);
                    bookCatalogDetailList.Add(bookCatalogDetail);
                }
                return bookCatalogDetailList;
            }
            return bookCatalogDetailList;
        }

        //public BookCatalog GetBookCatalogById(int id)
        //{
        //    return _bookCatalogRepository.GetBookCatalogById(id);
        //}

        //public int Create(BookCatalog bookCatalog)
        //{
        //    return _bookCatalogRepository.Create(bookCatalog);
        //}        

        //public int Update(BookCatalog bookCatalog)
        //{
        //    return _bookCatalogRepository.Update(bookCatalog);
        //}

        //public string Delete(int id)
        //{
        //    return _bookCatalogRepository.Delete(id);
        //}
    }
}
