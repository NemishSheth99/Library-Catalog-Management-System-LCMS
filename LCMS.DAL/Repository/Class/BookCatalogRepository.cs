using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Repository.Interface;
using LCMS.Models;
using AutoMapper;

namespace LCMS.DAL.Repository.Class
{
    public class BookCatalogRepository : IBookCatalogRepository
    {
        private readonly Database.LCMSDBEntities _dbContext;

        public BookCatalogRepository()
        {
            _dbContext = new Database.LCMSDBEntities();
        }

        public List<BookCatalog> GetBookCatalogs()
        {
            var list = _dbContext.BookCatalogs.Where(x => x.IsDeleted == false).ToList();
            List<BookCatalog> lst = new List<BookCatalog>();

            if (list != null)
            {
                foreach (var items in list)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.BookCatalog, BookCatalog>());
                    var mapper = new Mapper(config);
                    BookCatalog obj = mapper.Map<BookCatalog>(items);
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public BookCatalog GetBookCatalogById(int id)
        {
            try
            {
                BookCatalog bookCatalog = new BookCatalog();
                var obj = _dbContext.BookCatalogs.Find(id);
                if (obj != null)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.BookCatalog, BookCatalog>());
                    var mapper = new Mapper(config);
                    bookCatalog = mapper.Map<BookCatalog>(obj);
                    return bookCatalog;
                }
                return bookCatalog;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int Create(BookCatalog bookCatalog)
        {
            try
            {
                if (bookCatalog != null)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<BookCatalog, Database.BookCatalog>());
                    var mapper = new Mapper(config);
                    Database.BookCatalog obj = mapper.Map<Database.BookCatalog>(bookCatalog);
                    _dbContext.BookCatalogs.Add(obj);
                    _dbContext.SaveChanges();
                    int catalogId = obj.Id;
                    return catalogId;
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Update(BookCatalog bookCatalog)
        {
            try
            {
                var obj = _dbContext.BookCatalogs.Find(bookCatalog.Id);
                if (obj != null)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<BookCatalog, Database.BookCatalog>());
                    var mapper = new Mapper(config);
                    mapper.Map(bookCatalog, obj);
                    _dbContext.SaveChanges();
                    int catalogId = obj.Id;
                    return catalogId;
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public string Delete(int id)
        {
            try
            {
                var obj = _dbContext.BookCatalogs.Find(id);
                if (obj != null)
                {
                    obj.IsDeleted = true;
                    _dbContext.SaveChanges();
                    return "Success";
                }
                return "Fail";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
