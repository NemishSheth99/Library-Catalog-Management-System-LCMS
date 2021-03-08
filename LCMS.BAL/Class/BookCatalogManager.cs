using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.BAL.Interface;
using LCMS.DAL.Repository.Interface;
using LCMS.DAL.Database;
using LCMS.Models.BookCatalog;
using LCMS.Models.Author;
using AutoMapper;

namespace LCMS.BAL.Class
{
    public class BookCatalogManager : IBookCatalogManager
    {
        private readonly IBookCatalogRepository _bookCatalogRepository;
        private readonly IAuthorRepository _authorRepository;

        public BookCatalogManager(IBookCatalogRepository bookCatalogRepository,IAuthorRepository authorRepository)
        {
            _bookCatalogRepository = bookCatalogRepository;
            _authorRepository = authorRepository;
        }

        public List<BookCatalogDetail> GetBookCatalogs()
        {
            List<BookCatalog> bookCataloglist = _bookCatalogRepository.GetBookCatalogs();
            List<BookCatalogDetail> bookCatalogDetailList = new List<BookCatalogDetail>();
            if (bookCataloglist != null)
            {
                foreach (var items in bookCataloglist)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<BookCatalog, BookCatalogDetail>());
                    var mapper = new Mapper(config);
                    BookCatalogDetail bookCatalogDetail = mapper.Map<BookCatalogDetail>(items);
                    if(bookCatalogDetail!=null)
                    {
                        List<Author> authorList = _authorRepository.GetAuthorByBookcatalog(items.Id);
                        List<AuthorDetail> authorDetailList = new List<AuthorDetail>();
                        if(authorList!=null)
                        {
                            foreach(var i in authorList)
                            {
                                var cnfg= new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorDetail>());
                                var mp = new Mapper(cnfg);
                                AuthorDetail authorDetail = mp.Map<AuthorDetail>(i);
                                authorDetailList.Add(authorDetail);
                            }
                        }
                        string author = "";
                        foreach (var ath in authorDetailList)
                        {                            
                            author += ath.Name + ",";
                        }
                        bookCatalogDetail.Authors = author.Substring(0,author.Length-1);
                    }
                    bookCatalogDetailList.Add(bookCatalogDetail);
                }
                return bookCatalogDetailList;
            }
            return bookCatalogDetailList;
        }

        public BookCatalogDetail GetBookCatalogById(int id)
        {
            BookCatalogDetail bookCatalogDetail = new BookCatalogDetail();
            BookCatalog bookCatalog= _bookCatalogRepository.GetBookCatalogById(id);
            if(bookCatalog!=null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<BookCatalog, BookCatalogDetail>());
                var mapper = new Mapper(config);
                bookCatalogDetail = mapper.Map<BookCatalogDetail>(bookCatalog);
                return bookCatalogDetail;
            }
            return bookCatalogDetail;
        }

        public int Create(AddBookCatalog addBookCatalog)
        {
            BookCatalog bookCatalog = new BookCatalog();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddBookCatalog, BookCatalog>().ForMember(x => x.ISBN, y => y.Ignore()));
            var mapper = new Mapper(config);
            bookCatalog = mapper.Map<BookCatalog>(addBookCatalog);
            bookCatalog.ISBN = addBookCatalog.ISBN;
            return _bookCatalogRepository.Create(bookCatalog);
        }

        public int Update(AddBookCatalog addBookCatalog)
        {
            BookCatalog bookCatalog = new BookCatalog();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddBookCatalog, BookCatalog>().ForMember(x => x.ISBN, y => y.Ignore()));
            var mapper = new Mapper(config);
            bookCatalog = mapper.Map<BookCatalog>(addBookCatalog);
            bookCatalog.ISBN = addBookCatalog.ISBN;
            return _bookCatalogRepository.Update(bookCatalog);
        }

        public string Delete(int id)
        {
            return _bookCatalogRepository.Delete(id);
        }
    }
}
