using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.BookPlace;
using System.Globalization;

namespace LCMS.ServiceProxy.BookPlace
{
    public class BookPlaceServiceProxy : ServiceProxyBase, IBookPlaceServiceProxy
    {

        public BookPlaceServiceProxy()
        {
            ServiceUrlPrefix = "api/BookPlaceAPI";
        }

        public List<BookPlaceDetail> GetBookPlacesByCatalog(int bookCatalogId)
        {
            var queryParam = new Dictionary<string, string>
            {
                {"bookCatalogId", bookCatalogId.ToString(CultureInfo.InvariantCulture)}
            };
            return GetRequest<List<BookPlaceDetail>>("GetBooks", queryParam);
        }
    }
}
