using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Database;

namespace LCMS.DAL.Repository.Interface
{
    public interface IApplicationUserRoleRepository
    {
        ApplicationUserRole GetApplicationUserRole(int userId);
        string Create(ApplicationUserRole applicationUserRole);
        string Update(ApplicationUserRole applicationUserRole);
        string Delete(int userId);
    }
}
