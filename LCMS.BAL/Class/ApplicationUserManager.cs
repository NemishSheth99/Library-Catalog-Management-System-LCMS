using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.BAL.Interface;
using LCMS.DAL.Repository.Interface;
using LCMS.DAL.Database;
using LCMS.Models.ApplicationUser;
using LCMS.BAL.Helper;
using AutoMapper;

namespace LCMS.BAL.Class
{
    public class ApplicationUserManager : IApplicationUserManager
    {
        private readonly IApplicationUserRepository _applicationUserRepository;

        public ApplicationUserManager(IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }

        public ApplicationUserDetail Login(ApplicationUserLogin applicationUserLogin)
        {
            applicationUserLogin.Password = PasswordMD5.GetMD5(applicationUserLogin.Password);
            ApplicationUserDetail applicationUserDetail = new ApplicationUserDetail();
            ApplicationUser applicationUser = new ApplicationUser();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserLogin, ApplicationUser>());
            var mapper = new Mapper(config);
            applicationUser = mapper.Map<ApplicationUser>(applicationUserLogin);
            var appUser = _applicationUserRepository.Login(applicationUser);
            if (appUser != null)
            {
                var cnfg = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, ApplicationUserDetail>());
                var mp = new Mapper(cnfg);
                applicationUserDetail = mp.Map<ApplicationUserDetail>(appUser);
                return applicationUserDetail;
            }
            return applicationUserDetail;
        }

        public List<ApplicationUserDetail> GetApplicationUsers()
        {
            List<ApplicationUser> applicationUserList = _applicationUserRepository.GetApplicationUsers();
            List<ApplicationUserDetail> applicationUserDetailList = new List<ApplicationUserDetail>();
            if (applicationUserList != null)
            {
                foreach (var items in applicationUserList)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, ApplicationUserDetail>());
                    var mapper = new Mapper(config);
                    ApplicationUserDetail applicationUserDetail = mapper.Map<ApplicationUserDetail>(items);
                    applicationUserDetailList.Add(applicationUserDetail);
                }
                return applicationUserDetailList;
            }
            return applicationUserDetailList;
        }

        public ApplicationUserDetail GetApplicationUserById(int id)
        {
            ApplicationUser applicationUser = _applicationUserRepository.GetApplicationUserById(id);
            ApplicationUserDetail applicationUserDetail = new ApplicationUserDetail();
            if (applicationUser != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, ApplicationUserDetail>());
                var mapper = new Mapper(config);
                applicationUserDetail = mapper.Map<ApplicationUserDetail>(applicationUser);
                return applicationUserDetail;
            }
            return applicationUserDetail;
        }

        public ApplicationUserDetail GetApplicationUserByEmailAddress(string emailAddress)
        {
            ApplicationUser applicationUser = _applicationUserRepository.GetApplicationUserByEmail(emailAddress);
            ApplicationUserDetail applicationUserDetail = new ApplicationUserDetail();
            if (applicationUser != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, ApplicationUserDetail>());
                var mapper = new Mapper(config);
                applicationUserDetail = mapper.Map<ApplicationUserDetail>(applicationUser);
                return applicationUserDetail;
            }
            return applicationUserDetail;
        }

        public int Create(AddApplicationUserRequest applicationUserRequest)
        {
            applicationUserRequest.Password = PasswordMD5.GetMD5(applicationUserRequest.Password);
            ApplicationUser applicationUser = new ApplicationUser();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddApplicationUserRequest, ApplicationUser>());
            var mapper = new Mapper(config);
            applicationUser = mapper.Map<ApplicationUser>(applicationUserRequest);
            return _applicationUserRepository.Create(applicationUser);
        }

        public string Update(UpdateApplicationUserRequest applicationUserRequest)
        {
            ApplicationUser applicationUser = new ApplicationUser();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateApplicationUserRequest, ApplicationUser>());
            var mapper = new Mapper(config);
            applicationUser = mapper.Map<ApplicationUser>(applicationUserRequest);
            return _applicationUserRepository.Update(applicationUser);
        }

        public string UpdateActiveStatus(int id)
        {
            return _applicationUserRepository.UpdateActiveStatus(id);
        }

        public string Delete(int id)
        {
            return _applicationUserRepository.Delete(id);
        }

        public string ChangePassword(int id, string password)
        {
            password = PasswordMD5.GetMD5(password);
            return _applicationUserRepository.ChangePassword(id, password);
        }
    }
}
