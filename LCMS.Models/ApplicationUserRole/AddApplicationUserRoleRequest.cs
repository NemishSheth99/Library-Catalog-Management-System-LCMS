using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCMS.Models.ApplicationUserRole
{
    public class AddApplicationUserRoleRequest
    {
        public int Id { get; set; }
        public int? ApplicationUserId { get; set; }
        public int? RoleId { get; set; }
    }
}
