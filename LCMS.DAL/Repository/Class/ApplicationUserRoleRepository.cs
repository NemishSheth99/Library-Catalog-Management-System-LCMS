using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Repository.Interface;
using LCMS.DAL.Database;

namespace LCMS.DAL.Repository.Class
{
    public class ApplicationUserRoleRepository : IApplicationUserRoleRepository
    {
        private readonly Database.LCMSDBEntities _dbContext;

        public ApplicationUserRoleRepository()
        {
            _dbContext = new Database.LCMSDBEntities();
        }

        public ApplicationUserRole GetApplicationUserRole(int userId)
        {
            ApplicationUserRole role = new ApplicationUserRole();
            role = _dbContext.ApplicationUserRoles.Where(x => x.ApplicationUserId == userId).FirstOrDefault();
            if (role != null)
            {
                return role;
            }
            return role;
        }

        public string Create(ApplicationUserRole applicationUserRole)
        {
            if (applicationUserRole != null)
            {                
                _dbContext.ApplicationUserRoles.Add(applicationUserRole);
                _dbContext.SaveChanges();
                return "Success";
            }
            return "Fail";
        }

        public string Update(ApplicationUserRole applicationUserRole)
        {
            var role = _dbContext.ApplicationUserRoles.Where(x=>x.ApplicationUserId==applicationUserRole.ApplicationUserId).FirstOrDefault();
            if (role != null)
            {
                role.RoleId = applicationUserRole.RoleId;
                _dbContext.SaveChanges();
                return "Success";
            }
            return "Fail";
        }

        public string Delete(int userId)
        {
            var role = _dbContext.ApplicationUserRoles.Where(x => x.ApplicationUserId == userId).FirstOrDefault();
            if (role != null)
            {
                _dbContext.ApplicationUserRoles.Remove(role);
                _dbContext.SaveChanges();
                return "Success";
            }
            return "Fail";
        }

    }
}
