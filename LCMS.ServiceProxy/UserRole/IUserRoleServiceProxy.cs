using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCMS.ServiceProxy.UserRole
{
    public interface IUserRoleServiceProxy
    {
        int GetRoleId(string role);
    }
}
