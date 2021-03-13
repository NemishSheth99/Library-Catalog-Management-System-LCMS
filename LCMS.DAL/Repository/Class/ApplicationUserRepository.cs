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

        public int ActiveUserCount()
        {
            return _dbContext.ApplicationUsers.Where(x => x.IsDeleted == false && x.Status == "A").Count();
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

        //public int? GetInvalidAttemptCount(string emailAddress)
        //{
        //    return _dbContext.ApplicationUsers.Where(x => x.EmailAddress.Equals(emailAddress) && x.Status == "A" && x.IsDeleted == false).FirstOrDefault().InvalidAttemptCount;
        //}

        //public int? SetInvalidAttempt(string emailAddress, int attempt)
        //{
        //    ApplicationUser user = _dbContext.ApplicationUsers.Where(x => x.EmailAddress == emailAddress).FirstOrDefault();
        //    user.InvalidAttemptCount = attempt;
        //    if (_dbContext.SaveChanges() > 0)
        //        return user.InvalidAttemptCount;
        //    return null;
        //}

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

        public string ChangePassword(int id, string oldPassword, string newPassword)
        {
            ApplicationUser applicationUser = _dbContext.ApplicationUsers.Find(id);
            if (applicationUser != null)
            {
                if (applicationUser.Password == oldPassword)
                {
                    applicationUser.Password = newPassword;
                    _dbContext.SaveChanges();
                    return "Success";
                }
                else
                    return "Old Password does not match!!!";
            }
            return "Fail";
        }

        public List<ApplicationUser> SearchApplicationUser(string search)
        {
            List<ApplicationUser> applicationUserList = new List<ApplicationUser>();
            if (search != null)
                applicationUserList = _dbContext.ApplicationUsers.Where(x => x.Name.Contains(search) && x.IsDeleted==false).ToList();
            else
                applicationUserList = _dbContext.ApplicationUsers.Where(x=>x.IsDeleted==false).ToList();
            return applicationUserList;
        }

        public List<ApplicationUser> GetApplicationUsers(List<ApplicationUser> applicationUserList, int pageNo)
        {
            int NoOfRecordsPerPage = 15;
            int NoOfRecordsToSkip = (pageNo - 1) * NoOfRecordsPerPage;
            if (applicationUserList.Count > 0)
                applicationUserList = applicationUserList.OrderBy(x => x.Name).Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
            else
                applicationUserList = _dbContext.ApplicationUsers.OrderBy(x => x.Name).Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
            return applicationUserList;
        }

        public int GetCount(string search)
        {
            List<ApplicationUser> applicationUserList = _dbContext.ApplicationUsers.Where(x => x.IsDeleted == false).ToList();
            if (search != null)
                applicationUserList = applicationUserList.Where(x => x.Name.Contains(search) && x.IsDeleted==false).ToList();
            return applicationUserList.Count;
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
            ApplicationUser applicationUser = _dbContext.ApplicationUsers.Where(x => x.EmailAddress == emailAddress).FirstOrDefault();
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
            ApplicationUser user = _dbContext.ApplicationUsers.Where(x => x.Id == applicationUser.Id).FirstOrDefault();
            if (user != null)
            {
                user.Name = applicationUser.Name;
                user.EmailAddress = applicationUser.EmailAddress;
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
                applicationUser.Status = applicationUser.Status == "A" ? "B" : "A";
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
                _dbContext.SaveChanges();
                return "Success";

            }
            return "Fail";
        }

    }
}
