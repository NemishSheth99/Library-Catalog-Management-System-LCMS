using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.BookCatalog;

namespace LCMS.Models.BookPlace
{
    public class BookPlaceDetail
    {
        public int Id { get; set; }
        public int BookCatalogId { get; set; }
        public string PlaceCode { get; set; }
        public string MaterialType { get; set; }
        public int BorrowedBy { get; set; }
        public DateTime BorrowedOn { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual BookCatalogDetail BookCatalog { get; set; }
    }
}
