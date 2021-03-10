using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.BookCatalog;

namespace LCMS.ServiceProxy.BookCatalog
{
    public interface IBookCatalogServiceProxy
    {
        BookCatalogResponse GetBookCatalogs(int pageNo, string search);
        BookCatalogDetail GetBookCatalog(int id);

        int Create(AddBookCatalog addBookCatalog);
        int Update(AddBookCatalog addBookCatalog);
        string Delete(int id);
    }
}
