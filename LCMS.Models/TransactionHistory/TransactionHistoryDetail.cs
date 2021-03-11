using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.ApplicationUser;
using LCMS.Models.BookPlace;

namespace LCMS.Models.TransactionHistory
{
    public class TransactionHistoryDetail
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string TransactionType { get; set; }
        public int ApplicationUserId { get; set; }
        public DateTime TransactionDate { get; set; }

        public ApplicationUserDetail ApplicationUser { get; set; }
        public BookPlaceDetail BookPlace { get; set; }
    }
}
