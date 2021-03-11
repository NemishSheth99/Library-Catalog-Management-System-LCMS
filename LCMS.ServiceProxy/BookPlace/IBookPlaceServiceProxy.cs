using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.BookPlace;

namespace LCMS.ServiceProxy.BookPlace
{
    public interface IBookPlaceServiceProxy
    {
        List<BookPlaceDetail> GetBookPlacesByCatalog(int catalogId);
        BookPlaceDetail GetBookPlaceById(int id);
        int Create(AddBookPlace addBookPlace);
        int Update(AddBookPlace addBookPlace);
        string Delete(int id);

        List<BookPlaceDetail> GetAvailableBooksByCatalog(int catalogId);        
        List<BookPlaceDetail> GetUserCheckoutBooks(int userId);
        string CheckOutBookPlace(BookPlaceCheckOut bookPlaceCheckOut);
        string CheckInBookPlace(int id);
        int GetCheckOutCount();
        int UserCheckOutCount(int userId);
    }
}
