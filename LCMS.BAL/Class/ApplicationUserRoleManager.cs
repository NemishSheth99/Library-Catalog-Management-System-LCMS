using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.BAL.Interface;
using LCMS.DAL.Repository.Interface;
using LCMS.DAL.Database;
using LCMS.Models.ApplicationUserRole;
using LCMS.Models.UserRole;
using AutoMapper;

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
            ApplicationUserRoleDetail applicationUserRoleDetail = new ApplicationUserRoleDetail();
            ApplicationUserRole applicationUserRole = _applicationUserRoleRepository.GetApplicationUserRole(userId);
            if(applicationUserRole !=null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserRole, ApplicationUserRoleDetail>().ForMember(x => x.UserRole, y => y.Ignore()));
                var mapper = new Mapper(config);
                applicationUserRoleDetail = mapper.Map<ApplicationUserRoleDetail>(applicationUserRole);
                if (applicationUserRole.UserRole != null)
                {
                    var cnfg = new MapperConfiguration(cfg => cfg.CreateMap<UserRole, UserRoleDetail>());
                    var mp = new Mapper(cnfg);
                    applicationUserRoleDetail.UserRole = mp.Map<UserRoleDetail>(applicationUserRole.UserRole);
                }
            }
            return applicationUserRoleDetail;
        }

        public string Create(AddApplicationUserRoleRequest applicationUserRoleRequest)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddApplicationUserRoleRequest, ApplicationUserRole>());
            var mapper = new Mapper(config);
            ApplicationUserRole applicationUserRole = mapper.Map<ApplicationUserRole>(applicationUserRoleRequest);
            return _applicationUserRoleRepository.Create(applicationUserRole);
        }

        public string Update(AddApplicationUserRoleRequest applicationUserRoleRequest)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddApplicationUserRoleRequest, ApplicationUserRole>());
            var mapper = new Mapper(config);
            ApplicationUserRole applicationUserRole = mapper.Map<ApplicationUserRole>(applicationUserRoleRequest);
            return _applicationUserRoleRepository.Update(applicationUserRole);
        }

        public string Delete(int userId)
        {
            return _applicationUserRoleRepository.Delete(userId);
        }
    }
}
