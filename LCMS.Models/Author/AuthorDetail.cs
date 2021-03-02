using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCMS.Models.Author
{
    public class AuthorDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BookCatalogId { get; set; }
    }
}
