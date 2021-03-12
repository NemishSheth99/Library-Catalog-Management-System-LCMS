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

        public BookCatalogResponse GetBookCatalogs(int pageNo, string search)
        {
            var queryParam = new Dictionary<string, string>
            {
                {"pageNo", pageNo.ToString(CultureInfo.InvariantCulture)},
                {"search", search.ToString(CultureInfo.InvariantCulture)}
            };
            return GetRequest<BookCatalogResponse>("GetBookCatalogs", queryParam);
        }

        public BookCatalogDetail GetBookCatalog(int id)
        {
            var queryParam = new Dictionary<string, string>
            {
                {"id", id.ToString(CultureInfo.InvariantCulture)}
            };
            return GetRequest<BookCatalogDetail>("GetBookCatalog", queryParam);
        }

        public int Create(AddBookCatalog addBookCatalog)
        {
            return MakeRequest<int, AddBookCatalog>("AddBookCatalog", ServiceRequestType.Post, addBookCatalog);
        }

        public int Update(AddBookCatalog addBookCatalog)
        {
            return MakeRequest<int, AddBookCatalog>("UpdateBookCatalog", ServiceRequestType.Put, addBookCatalog);
        }

        public string Delete(int id)
        {
            return MakeRequest<string, int>("DeleteBookCatalog/" + id, ServiceRequestType.Delete, 0);
        }

        public int ActiveCatalogCount()
        {
            var queryParam = new Dictionary<string, string> { };
            return GetRequest<int>("ActiveCatalogCount", queryParam);
        }
    }
}
