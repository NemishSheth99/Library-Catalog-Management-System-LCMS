using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.Author;

namespace LCMS.BAL.Interface
{
    public interface IAuthorManager
    {
        List<AuthorDetail> GetAuthorByBookcatalog(int bookCatalogId);
        string Create(AuthorDetail author);
        string DeleteBookAuthors(AuthorDetail author);
        string Delete(int bookCatalogId);
    }
}
