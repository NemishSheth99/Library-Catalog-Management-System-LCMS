using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.BAL.Interface;
using LCMS.DAL.Repository.Interface;
using LCMS.DAL.Database;
using LCMS.Models.UserRole;
using AutoMapper;

namespace LCMS.BAL.Class
{
    public class UserRoleManager : IUserRoleManager
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleManager(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public List<UserRoleDetail> GetUserRoleDetails()
        {
            List<UserRole> userRoles = _userRoleRepository.GetUserRoles();
            List<UserRoleDetail> userRoleDetailList = new List<UserRoleDetail>();
            
            if (userRoles != null)
            {
                foreach (var items in userRoles)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<UserRole, UserRoleDetail>());
                    var mapper = new Mapper(config);
                    UserRoleDetail userRoleDetail = mapper.Map<UserRoleDetail>(items);
                    userRoleDetailList.Add(userRoleDetail);
                }
                return userRoleDetailList;
            }
            return userRoleDetailList;
        }

        public int GetRoleId(string role)
        {
            return _userRoleRepository.GetRoleId(role);
        }
                
    }
}
