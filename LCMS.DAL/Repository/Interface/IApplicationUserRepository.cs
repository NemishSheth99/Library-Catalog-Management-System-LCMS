using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Database;

namespace LCMS.DAL.Repository.Interface
{
    public interface IApplicationUserRepository
    {
        int ActiveUserCount();
        ApplicationUser Login(ApplicationUser applicationUser);
        //int? GetInvalidAttemptCount(string emailAddress);
        //int? SetInvalidAttempt(string emailAddress, int attempt);
        string EditProfile(ApplicationUser applicationUser);
        string ChangePassword(int id, string oldPassword, string newPassword);

        List<ApplicationUser> SearchApplicationUser(string search);
        List<ApplicationUser> GetApplicationUsers(List<ApplicationUser> applicationUserList,int pageNo);
        int GetCount(string search);
        ApplicationUser GetApplicationUserById(int id);
        ApplicationUser GetApplicationUserByEmail(string emailAddress);
        int Create(ApplicationUser applicationUser);
        string Update(ApplicationUser applicationUser);        
        string UpdateActiveStatus(int id);
        string Delete(int id);
    }
}
