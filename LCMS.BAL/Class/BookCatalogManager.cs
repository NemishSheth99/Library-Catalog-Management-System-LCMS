using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.BAL.Interface;
using LCMS.DAL.Repository.Interface;

namespace LCMS.BAL.Class
{
    public class BookCatalogManager : IBookCatalogManager
    {
        private readonly IBookCatalogRepository _bookCatalogRepository;

        public BookCatalogManager(IBookCatalogRepository bookCatalogRepository)
        {
            _bookCatalogRepository = bookCatalogRepository;
        }

        //public List<BookCatalog> GetBookCatalogs()
        //{
        //    return _bookCatalogRepository.GetBookCatalogs();
        //}

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
