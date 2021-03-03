using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Repository.Interface;
using LCMS.DAL.Database;

namespace LCMS.DAL.Repository.Class
{
    public class BookPlaceRepository : IBookPlaceRepository
    {
        private readonly Database.LCMSDBEntities _dbContext;

        public BookPlaceRepository()
        {
            _dbContext = new Database.LCMSDBEntities();
        }

        public List<BookPlace> GetBookPlacesByCatalog(int catalogId)
        {
            List<BookPlace> list = _dbContext.BookPlaces.Where(x => x.BookCatalogId == catalogId && x.IsDeleted == false).ToList();            
            return list;
        }

        //public BookPlace GetBookPlaceById(int id)
        //{
        //    try
        //    {
        //        BookPlace book = new BookPlace();
        //        var obj = _dbContext.BookCatalogs.Find(id);
        //        if (obj != null)
        //        {
        //            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.BookPlace, BookPlace>());
        //            var mapper = new Mapper(config);
        //            book = mapper.Map<BookPlace>(obj);
        //            return book;
        //        }
        //        return book;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public int Create(BookPlace bookPlace)
        //{
        //    try
        //    {
        //        if (bookPlace != null)
        //        {
        //            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookPlace, Database.BookPlace>());
        //            var mapper = new Mapper(config);
        //            Database.BookPlace obj = mapper.Map<Database.BookPlace>(bookPlace);
        //            _dbContext.BookPlaces.Add(obj);
        //            _dbContext.SaveChanges();
        //            int bookId = obj.Id;
        //            return bookId;
        //        }
        //        return 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }
        //}

        //public int Update(BookPlace bookPlace)
        //{
        //    try
        //    {
        //        var obj = _dbContext.BookCatalogs.Find(bookPlace.Id);
        //        if (obj != null)
        //        {
        //            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookPlace, Database.BookPlace>());
        //            var mapper = new Mapper(config);
        //            mapper.Map(bookPlace, obj);
        //            _dbContext.SaveChanges();
        //            int bookId = obj.Id;
        //            return bookId;
        //        }
        //        return 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }
        //}

        //public string Delete(int id)
        //{
        //    try
        //    {
        //        var obj = _dbContext.BookPlaces.Find(id);
        //        if (obj != null)
        //        {
        //            obj.IsDeleted = true;
        //            _dbContext.SaveChanges();
        //            return "Success";
        //        }
        //        return "Fail";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}

        //public string CheckInBook(int id, int userId)
        //{
        //    try
        //    {
        //        var obj = _dbContext.BookPlaces.Find(id);
        //        if (obj != null)
        //        {
        //            obj.BorrowedBy = userId;
        //            obj.BorrowedOn = DateTime.Now;
        //            _dbContext.SaveChanges();
        //            return "Success";
        //        }
        //        return "Fail";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}        

        //public string CheckOutBook(int id)
        //{
        //    try
        //    {
        //        var obj = _dbContext.BookPlaces.Find(id);
        //        if (obj != null)
        //        {
        //            obj.BorrowedBy = null;
        //            obj.BorrowedOn = null;
        //            _dbContext.SaveChanges();
        //            return "Success";
        //        }
        //        return "Fail";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}
    }
}
