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
    public class AuthorManager : IAuthorManager
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorManager(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        //public string Create(Author author)
        //{
        //    return _authorRepository.Create(author);
        //}

        //public string Update(Author author)
        //{
        //    return _authorRepository.Update(author);
        //}

        //public string Delete(int bookCatalogId)
        //{
        //    return _authorRepository.Delete(bookCatalogId);
        //}
    }
}
