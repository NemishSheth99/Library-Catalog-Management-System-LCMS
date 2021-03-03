using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.BookCatalog;
using System.Globalization;

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

        public BookCatalogDetail GetBookCatalog(int id)
        {
            var queryParam = new Dictionary<string, string>
            {
                {"id", id.ToString(CultureInfo.InvariantCulture)}
            };
            return GetRequest<BookCatalogDetail>("GetBookCatalog", queryParam);
        }
    }
}
