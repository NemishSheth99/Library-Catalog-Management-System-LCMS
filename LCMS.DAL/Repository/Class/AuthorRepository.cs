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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly Database.LCMSDBEntities _dbContext;

        public AuthorRepository()
        {
            _dbContext = new Database.LCMSDBEntities();
        }

        public string Create(Author author)
        {
            try
            {
                if (author != null)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Author, Database.Author>());
                    var mapper = new Mapper(config);
                    Database.Author obj = mapper.Map<Database.Author>(author);
                    _dbContext.Authors.Add(obj);
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

        public string Update(Author author)
        {
            try
            {
                var aut = _dbContext.Authors.Where(x=>x.BookCatalogId==author.BookCatalogId);
                if (aut != null)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Author, Database.Author>());
                    var mapper = new Mapper(config);
                    mapper.Map(author, aut);
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

        public string Delete(int bookCatalogId)
        {
            try
            {
                var obj = _dbContext.Authors.Where(x=>x.BookCatalogId==bookCatalogId).FirstOrDefault();
                if (obj != null)
                {
                    _dbContext.Authors.Remove(obj);
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
