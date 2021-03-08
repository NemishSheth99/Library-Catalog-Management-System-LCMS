using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCMS.Models.ApplicationUser
{
    public class ApplicationUserResponse
    {
        public List<ApplicationUserDetail> ApplicationUserList { get; set; }

        public int Count { get; set; }
    }
}
