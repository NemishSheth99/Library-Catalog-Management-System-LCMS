using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Database;

namespace LCMS.DAL.Repository.Interface
{
    public interface IBookPlaceRepository
    {
        List<BookPlace> GetBookPlacesByCatalog(int catalogId);
        
        BookPlace GetBookPlaceById(int id);
        int Create(BookPlace bookPlace);
        int Update(BookPlace bookPlace);
        string Delete(int id);

        List<BookPlace> GetAvailableBooksByCatalog(int catalogId);
        List<BookPlace> GetUserCheckOutBooks(int userId);
        string CheckInBook(int id);
        string CheckOutBook(int id, int userId);

        int GetCheckOutCount();
        int UserCheckOutCount(int userId);
    }
}
