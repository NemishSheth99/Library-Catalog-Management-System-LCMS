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
        List<BookPlaceDetail> GetAvailableBooksByCatalog(int catalogId);
        List<BookPlaceDetail> GetUserCheckOutBooks(int userId);
        //BookPlace GetBookPlaceById(int id);
        int Create(AddBookPlace bookPlace);
        //int Update(BookPlace bookPlace);
        //string Delete(int id);
        string CheckInBook(int id);
        string CheckOutBook(int id, int userId);
    }
}
