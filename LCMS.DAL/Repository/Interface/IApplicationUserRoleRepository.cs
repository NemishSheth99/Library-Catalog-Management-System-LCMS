using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.ApplicationUserRole;

namespace LCMS.DAL.Repository.Interface
{
    public interface IApplicationUserRoleRepository
    {
        ApplicationUserRoleDetail GetApplicationUserRoleDetail(int userId);
        //string Create(ApplicationUserRole applicationUserRole);
        //string Update(ApplicationUserRole applicationUserRole);
        //string Delete(int userId);
    }
}
