using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Repository.Interface;
using LCMS.DAL.Database;

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
            return list;
        }

        public BookCatalog GetBookCatalogById(int id)
        {
            BookCatalog bookCatalog = _dbContext.BookCatalogs.Where(x => x.Id == id).FirstOrDefault();
            if (bookCatalog != null)
            {
                return bookCatalog;
            }
            return bookCatalog;
        }

        public int Create(BookCatalog bookCatalog)
        {
            if (bookCatalog != null)
            {
                _dbContext.BookCatalogs.Add(bookCatalog);
                if (_dbContext.SaveChanges() > 0)
                    return bookCatalog.Id;
            }
            return 0;
        }

        public int Update(BookCatalog bookCatalog)
        {
            BookCatalog catalog = _dbContext.BookCatalogs.Find(bookCatalog.Id);
            if (catalog != null)
            {
                catalog.Name = bookCatalog.Name;
                catalog.Summary = bookCatalog.Summary;
                catalog.ISBN = bookCatalog.ISBN;
                catalog.PublicationYear = bookCatalog.PublicationYear;
                catalog.CoverImage = bookCatalog.CoverImage;
                catalog.ImageContentType = bookCatalog.ImageContentType;                
                catalog.Edition = bookCatalog.Edition;
                catalog.UpdatedDate = bookCatalog.UpdatedDate;
                if (_dbContext.SaveChanges() > 0)
                {
                    int catalogId = catalog.Id;
                    return catalogId;
                }
            }
            return 0;
        }

        public string Delete(int id)
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
    }
}
