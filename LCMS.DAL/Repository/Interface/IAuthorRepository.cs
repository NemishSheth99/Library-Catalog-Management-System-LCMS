﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Database;

namespace LCMS.DAL.Repository.Interface
{
    public interface IAuthorRepository
    {
        List<Author> GetAuthorByBookcatalog(int bookCatalogId);
        string Create(Author author);
        string DeleteBookAuthors(Author author);

        string Delete(int bookCatalogId);
    }
}
