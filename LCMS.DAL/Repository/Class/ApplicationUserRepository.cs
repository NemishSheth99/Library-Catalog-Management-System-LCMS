using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Repository.Interface;
using LCMS.DAL.Database;

namespace LCMS.DAL.Repository.Class
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly Database.LCMSDBEntities _dbContext;

        public ApplicationUserRepository()
        {
            _dbContext = new Database.LCMSDBEntities();
        }

        public ApplicationUser Login(ApplicationUser applicationUser)
        {
            var user = _dbContext.ApplicationUsers.Where(x => x.EmailAddress == applicationUser.EmailAddress && x.Password == applicationUser.Password && x.Status == "A" && x.IsDeleted == false).FirstOrDefault();            
            if (user != null)
            {
                return user;
            }
            return user;

        }

        public List<ApplicationUser> GetApplicationUsers()
        {
            var list = _dbContext.ApplicationUsers.Where(x => x.IsDeleted == false).ToList();
            return list;
        }

        public ApplicationUser GetApplicationUserById(int id)
        {
            ApplicationUser applicationUser = _dbContext.ApplicationUsers.Find(id);
            if (applicationUser != null)
            {
                return applicationUser;
            }
            return applicationUser;
        }

        public ApplicationUser GetApplicationUserByEmail(string emailAddress)
        {
            ApplicationUser applicationUser = _dbContext.ApplicationUsers.Where(x=>x.EmailAddress==emailAddress).FirstOrDefault();
            if (applicationUser != null)
            {
                return applicationUser;
            }
            return applicationUser;
        }

        public int Create(ApplicationUser applicationUser)
        {
            if (applicationUser != null)
            {
                applicationUser.Status = "A";
                applicationUser.IsDeleted = false;
                _dbContext.ApplicationUsers.Add(applicationUser);
                _dbContext.SaveChanges();
                return applicationUser.Id;
            }
            return 0;
        }

        public string Update(ApplicationUser applicationUser)
        {
            ApplicationUser user = _dbContext.ApplicationUsers.Find(applicationUser.Id);
            if (user != null)
            {
                _dbContext.Entry(user).CurrentValues.SetValues(applicationUser);
                if (applicationUser.Status == null)
                    user.Status = user.Status;
                if (applicationUser.IsDeleted == null)
                    user.IsDeleted = user.IsDeleted;
                _dbContext.SaveChanges();
                return "Success";
            }
            return "Fail";
        }

        public string EditProfile(ApplicationUser applicationUser)
        {
            ApplicationUser user = _dbContext.ApplicationUsers.Find(applicationUser.Id);
            if (user != null)
            {
                user.Name = applicationUser.Name;
                user.PhoneNumber = applicationUser.PhoneNumber;
                _dbContext.SaveChanges();
                return "Success";
            }
            return "Fail";
        }

        public string UpdateActiveStatus(int id)
        {
            ApplicationUser applicationUser = _dbContext.ApplicationUsers.Find(id);
            if (applicationUser != null)
            {
                applicationUser.Status = applicationUser.Status=="A"?"B":"A";
                _dbContext.SaveChanges();
                return "Success";
            }
            return "Fail";
        }

        public string Delete(int id)
        {
            ApplicationUser applicationUser = _dbContext.ApplicationUsers.Find(id);
            if (applicationUser != null)
            {
                applicationUser.IsDeleted = true;
                if (_dbContext.SaveChanges() > 0)
                    return "Success";
                else
                    return "Fail";
            }
            return "Fail";
        }

        public string ChangePassword(int id,string password)
        {
            ApplicationUser applicationUser = _dbContext.ApplicationUsers.Find(id);
            if (applicationUser != null)
            {
                applicationUser.Password = password;
                _dbContext.SaveChanges();
                return "Success";
            }
            return "Fail";
        }

        
    }
}
