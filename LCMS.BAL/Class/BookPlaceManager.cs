using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.BAL.Interface;
using LCMS.DAL.Repository.Interface;
using LCMS.Models;

namespace LCMS.BAL.Class
{
    public class BookPlaceManager : IBookPlaceManager
    {
        private readonly IBookPlaceRepository _bookPlaceRepository;

        public BookPlaceManager(IBookPlaceRepository bookPlaceRepository)
        {
            _bookPlaceRepository = bookPlaceRepository;
        }

        //public List<BookPlace> GetBookPlacesByCatalog(int catalogId)
        //{
        //    return _bookPlaceRepository.GetBookPlacesByCatalog(catalogId);
        //}

        //public BookPlace GetBookPlaceById(int id)
        //{
        //    return _bookPlaceRepository.GetBookPlaceById(id);
        //}

        //public int Create(BookPlace bookPlace)
        //{
        //    return _bookPlaceRepository.Create(bookPlace);
        //}

        //public int Update(BookPlace bookPlace)
        //{
        //    return _bookPlaceRepository.Update(bookPlace);
        //}

        //public string Delete(int id)
        //{
        //    return _bookPlaceRepository.Delete(id);
        //}

        //public string CheckInBook(int id, int userId)
        //{
        //    return _bookPlaceRepository.CheckInBook(id, userId);
        //}

        //public string CheckOutBook(int id)
        //{
        //    return _bookPlaceRepository.CheckOutBook(id);
        //}
    }
}
