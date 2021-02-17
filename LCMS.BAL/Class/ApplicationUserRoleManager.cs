using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.BAL.Interface;
using LCMS.DAL.Repository.Interface;
using LCMS.Models.ApplicationUserRole;

namespace LCMS.BAL.Class
{
    public class ApplicationUserRoleManager : IApplicationUserRoleManager
    {
        private readonly IApplicationUserRoleRepository _applicationUserRoleRepository;

        public ApplicationUserRoleManager(IApplicationUserRoleRepository applicationUserRoleRepository)
        {
            _applicationUserRoleRepository = applicationUserRoleRepository;
        }

        public ApplicationUserRoleDetail GetApplicationUserRoleDetail(int userId)
        {
            return _applicationUserRoleRepository.GetApplicationUserRoleDetail(userId);
        }

        //public string Create(ApplicationUserRole applicationUserRole)
        //{
        //    return _applicationUserRoleRepository.Create(applicationUserRole);
        //}

        //public string Update(ApplicationUserRole applicationUserRole)
        //{
        //    return _applicationUserRoleRepository.Update(applicationUserRole);
        //}

        //public string Delete(int userId)
        //{
        //    return _applicationUserRoleRepository.Delete(userId);
        //}        
    }
}
