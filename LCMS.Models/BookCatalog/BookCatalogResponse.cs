using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCMS.Models.BookCatalog
{
    public class BookCatalogResponse
    {
        public List<BookCatalogDetail> BookCatalogList { get; set; }

        public int Count { get; set; }
    }
}
