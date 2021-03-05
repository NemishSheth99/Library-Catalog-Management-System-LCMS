using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.BookPlace;

namespace LCMS.BAL.Interface
{
    public interface IBookPlaceManager
    {
        List<BookPlaceDetail> GetBookPlacesByCatalog(int catalogId);
        BookPlaceDetail GetBookPlaceById(int id);
        int Create(AddBookPlace bookPlace);
        int Update(AddBookPlace bookPlace);
        string Delete(int id);


        List<BookPlaceDetail> GetAvailableBooksByCatalog(int catalogId);
        List<BookPlaceDetail> GetUserCheckOutBooks(int userId);       
        string CheckInBook(int id);
        string CheckOutBook(int id, int userId);
    }
}
