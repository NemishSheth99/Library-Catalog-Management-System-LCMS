using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.BAL.Interface;
using LCMS.DAL.Repository.Interface;
using LCMS.DAL.Database;
using LCMS.Models.Author;
using AutoMapper;

namespace LCMS.BAL.Class
{
    public class AuthorManager : IAuthorManager
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorManager(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public List<AuthorDetail> GetAuthorByBookcatalog(int bookCatalogId)
        {
            List<Author> authorList = _authorRepository.GetAuthorByBookcatalog(bookCatalogId);
            List<AuthorDetail> authorDetailList = new List<AuthorDetail>();
            if(authorList!=null)
            {
                foreach(var items in authorList)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorDetail>());
                    var mapper = new Mapper(config);
                    AuthorDetail authorDetail = mapper.Map<AuthorDetail>(items);
                    authorDetailList.Add(authorDetail);
                }
                return authorDetailList;
            }
            return authorDetailList;
        }

        public string Create(AuthorDetail authorDetail)
        {
            Author author = new Author();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDetail, Author>());
            var mapper = new Mapper(config);
            author = mapper.Map<Author>(authorDetail);
            return _authorRepository.Create(author);
        }

        public string DeleteBookAuthors(AuthorDetail authorDetail)
        {
            Author author = new Author();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDetail, Author>());
            var mapper = new Mapper(config);
            author = mapper.Map<Author>(authorDetail);
            return _authorRepository.DeleteBookAuthors(author);
        }

        public string Delete(int bookCatalogId)
        {
            return _authorRepository.Delete(bookCatalogId);
        }
    }
}
