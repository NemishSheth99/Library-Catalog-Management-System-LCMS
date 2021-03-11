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
        BookCatalogResponse GetBookCatalogs(int pageNo, string search);
        BookCatalogDetail GetBookCatalogById(int id);
        int Create(AddBookCatalog addBookCatalog);
        int Update(AddBookCatalog addBookCatalog);
        string Delete(int id);
        int ActiveCatalogCount();
    }
}
