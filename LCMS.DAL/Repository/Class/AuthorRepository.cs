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

        //public string Update(Author author)
        //{
        //    try
        //    {
        //        var aut = _dbContext.Authors.Where(x=>x.BookCatalogId==author.BookCatalogId);
        //        if (aut != null)
        //        {
        //            var config = new MapperConfiguration(cfg => cfg.CreateMap<Author, Database.Author>());
        //            var mapper = new Mapper(config);
        //            mapper.Map(author, aut);
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
