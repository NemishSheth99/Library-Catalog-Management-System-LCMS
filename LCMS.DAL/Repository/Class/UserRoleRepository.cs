using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Repository.Interface;
using LCMS.Models.UserRole;
using AutoMapper;

namespace LCMS.DAL.Repository.Class
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly Database.LCMSDBEntities _dbContext;

        public UserRoleRepository()
        {
            _dbContext = new Database.LCMSDBEntities();
        }

        public int GetRoleId(string role)
        {
            int roleId = _dbContext.UserRoles.Where(x => x.Role == role).FirstOrDefault().Id;
            return roleId;
        }
    }
}
