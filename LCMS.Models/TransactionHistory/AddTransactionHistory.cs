using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCMS.Models.TransactionHistory
{
    public class AddTransactionHistory
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string TransactionType { get; set; }
        public int ApplicationUserId { get; set; }
        public DateTime TrasactionDate { get; set; }
    }
}
