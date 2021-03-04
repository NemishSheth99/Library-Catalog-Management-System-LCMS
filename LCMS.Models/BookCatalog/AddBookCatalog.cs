using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCMS.Models.BookCatalog
{
    public class AddBookCatalog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public string Edition { get; set; }
        public string CoverImage { get; set; }
        public string ImageContentType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
