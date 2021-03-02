using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.BookCatalog;

namespace LCMS.ServiceProxy.BookCatalog
{
    public class BookCatalogServiceProxy : ServiceProxyBase, IBookCatalogServiceProxy
    {
        public BookCatalogServiceProxy()
        {
            ServiceUrlPrefix = "api/BookCatalogAPI";
        }

        public List<BookCatalogDetail> GetBookCatalogs()
        {
            var queryParam = new Dictionary<string, string>();
            return GetRequest<List<BookCatalogDetail>>("GetBookCatalogs", queryParam);
        }
    }
}
