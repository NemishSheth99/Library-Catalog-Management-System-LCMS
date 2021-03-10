using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Database;

namespace LCMS.DAL.Repository.Interface
{
    public interface IBookCatalogRepository
    {
        List<BookCatalog> SearchBookCatalog(string search);
        List<BookCatalog> GetBookCatalogs(List<BookCatalog> bookCatalogList,int pageNo);
        int GetCount(string search);
        BookCatalog GetBookCatalogById(int id);
        int Create(BookCatalog bookCatalog);
        int Update(BookCatalog bookCatalog);
        string Delete(int id);
    }
}
