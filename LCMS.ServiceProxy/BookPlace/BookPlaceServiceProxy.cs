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

        public List<BookPlaceDetail> GetAvailableBooksByCatalog(int bookCatalogId)
        {
            var queryParam = new Dictionary<string, string>
            {
                {"bookCatalogId", bookCatalogId.ToString(CultureInfo.InvariantCulture)}
            };
            return GetRequest<List<BookPlaceDetail>>("GetAvailableBooks", queryParam);
        }

        public List<BookPlaceDetail> GetUserCheckoutBooks(int userId)
        {
            var queryParam = new Dictionary<string, string>
            {
                {"userId", userId.ToString(CultureInfo.InvariantCulture)}
            };
            return GetRequest<List<BookPlaceDetail>>("GetUserCheckoutBooks", queryParam);
        }

        public string CheckInBookPlace(int id)
        {
            return MakeRequest<string, int>("CheckInBookPlace/" + id, ServiceRequestType.Put, id);
        }

        public string CheckOutBookPlace(BookPlaceCheckOut bookPlaceCheckOut)
        {
            return MakeRequest<string, BookPlaceCheckOut>("CheckOutBookPlace", ServiceRequestType.Put, bookPlaceCheckOut);
        }

        public int Create(AddBookPlace addBookPlace)
        {
            return MakeRequest<int, AddBookPlace>("AddBookPlace", ServiceRequestType.Post, addBookPlace);
        }
    }
}
