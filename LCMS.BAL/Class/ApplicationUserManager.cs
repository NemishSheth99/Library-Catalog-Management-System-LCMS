using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.BAL.Interface;
using LCMS.DAL.Repository.Interface;
using LCMS.Models.ApplicationUser;

namespace LCMS.BAL.Class
{
    public class ApplicationUserManager :IApplicationUserManager
    {
        private readonly IApplicationUserRepository _applicationUserRepository;

        public ApplicationUserManager(IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }

        public ApplicationUserDetail Login(ApplicationUserLogin applicationUserLogin)
        {
            return _applicationUserRepository.Login(applicationUserLogin);
        }

        public List<ApplicationUserDetail> GetApplicationUsers()
        {
            return _applicationUserRepository.GetApplicationUsers();
        }

        public ApplicationUserDetail GetApplicationUserById(int id)
        {
            return _applicationUserRepository.GetApplicationUserById(id);
        }

        public int Create(AddApplicationUserRequest applicationUserRequest)
        {
            return _applicationUserRepository.Create(applicationUserRequest);
        }

        public string Update(AddApplicationUserRequest applicationUserRequest)
        {
            return _applicationUserRepository.Update(applicationUserRequest);
        }

        //public string UpdateActiveStatus(int id, string status)
        //{
        //    return _applicationUserRepository.UpdateActiveStatus(id, status);
        //}

        //public string Delete(int id)
        //{
        //    return _applicationUserRepository.Delete(id);
        //}
    }
}
