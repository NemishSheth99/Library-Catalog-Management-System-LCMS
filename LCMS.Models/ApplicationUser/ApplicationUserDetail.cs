using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCMS.Models.ApplicationUser
{
    public class ApplicationUserDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public bool? IsDeleted { get; set; }
        //public string Role { get; set; }
    }
}
