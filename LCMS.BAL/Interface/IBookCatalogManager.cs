﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models;

namespace LCMS.BAL.Interface
{
    public interface IBookCatalogManager
    {
        List<BookCatalog> GetBookCatalogs();
        BookCatalog GetBookCatalogById(int id);
        int Create(BookCatalog bookCatalog);
        int Update(BookCatalog bookCatalog);
        string Delete(int id);
    }
}