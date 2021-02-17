using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models;

namespace LCMS.BAL.Interface
{
    public interface IAuthorManager
    {
        string Create(Author author);
        string Update(Author author);
        string Delete(int bookCatalogId);
    }
}
