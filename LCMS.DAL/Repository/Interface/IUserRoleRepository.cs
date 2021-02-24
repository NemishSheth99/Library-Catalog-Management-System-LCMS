using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Database;

namespace LCMS.DAL.Repository.Interface
{
    public interface IUserRoleRepository
    {
        List<UserRole> GetUserRoles();
        int GetRoleId(string role);
    }
}
