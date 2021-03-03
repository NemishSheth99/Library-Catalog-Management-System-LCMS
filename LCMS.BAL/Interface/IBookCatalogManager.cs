using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.BookCatalog;

namespace LCMS.BAL.Interface
{
    public interface IBookCatalogManager
    {
        List<BookCatalogDetail> GetBookCatalogs();
        BookCatalogDetail GetBookCatalogById(int id);
        //int Create(BookCatalog bookCatalog);
        //int Update(BookCatalog bookCatalog);
        //string Delete(int id);
    }
}
