using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.UserRole;

namespace LCMS.Models.ApplicationUserRole
{
    public class ApplicationUserRoleDetail
    {
        public int Id { get; set; }
        public int? ApplicationUserId { get; set; }
        public UserRoleDetail UserRole { get; set; }
    }
}
