using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Database;
using LCMS.DAL.Repository.Interface;
//using LCMS.Models;


namespace LCMS.DAL.Repository.Class
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly Database.LCMSDBEntities _dbContext;

        public AuthorRepository()
        {
            _dbContext = new Database.LCMSDBEntities();
        }

        public List<Author> GetAuthorByBookcatalog(int bookCatalogId)
        {
            List<Author> authorList = _dbContext.Authors.Where(x => x.BookCatalogId == bookCatalogId).ToList();
            return authorList;
        }

        public string Create(Author author)
        {
            if (author != null)
            {
                _dbContext.Authors.Add(author);
                if (_dbContext.SaveChanges() > 0)
                    return "Success";
            }
            return "Fail";
        }

        public string DeleteBookAuthors(Author author)
        {
            List<Author> authorList = _dbContext.Authors.Where(x => x.BookCatalogId == author.BookCatalogId && x.Name.Equals(author.Name)).ToList();
            if (authorList != null)
            {
                foreach (var items in authorList)
                {
                    _dbContext.Authors.Remove(items);
                    _dbContext.SaveChanges();
                }
                return "Success";
            }
            return "Fail";
        }

        public string Delete(int bookCatalogId)
        {
            List<Author> authorList = _dbContext.Authors.Where(x => x.BookCatalogId == bookCatalogId).ToList();
            if (authorList != null)
            {
                foreach (var items in authorList)
                {
                    _dbContext.Authors.Remove(items);
                    _dbContext.SaveChanges();
                }
                return "Success";
            }
            return "Fail";
        }
    }
}
