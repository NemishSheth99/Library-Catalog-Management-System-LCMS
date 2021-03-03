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
        List<BookCatalogDetail> GetBookCatalogs();
    }
}
