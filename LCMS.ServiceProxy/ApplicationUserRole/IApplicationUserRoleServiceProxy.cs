using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.ApplicationUserRole;

namespace LCMS.ServiceProxy.ApplicationUserRole
{
    public interface IApplicationUserRoleServiceProxy
    {
        ApplicationUserRoleDetail GetRoleDetail(int id);
        string Create(AddApplicationUserRoleRequest applicationUserRoleRequest);

        string Update(AddApplicationUserRoleRequest applicationUserRoleRequest);
    }
}
