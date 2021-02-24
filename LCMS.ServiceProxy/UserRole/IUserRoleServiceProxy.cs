using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.UserRole;

namespace LCMS.ServiceProxy.UserRole
{
    public interface IUserRoleServiceProxy
    {
        List<UserRoleDetail> GetUserRoleDetails();
        int GetRoleId(string role);
    }
}
