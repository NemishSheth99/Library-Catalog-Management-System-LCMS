using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.UserRole;

namespace LCMS.BAL.Interface
{
    public interface IUserRoleManager
    {
        List<UserRoleDetail> GetUserRoleDetails();
        int GetRoleId(string role);
    }
}
