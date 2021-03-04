using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.Author;

namespace LCMS.ServiceProxy.Author
{
    public interface IAuthorServiceProxy
    {
        string Create(AuthorDetail authorDetail);
        string Delete(int bookCatalogId);
    }
}
