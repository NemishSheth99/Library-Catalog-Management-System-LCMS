using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Database;
using LCMS.Models.ApplicationUser;

namespace LCMS.BAL.Interface
{
    public interface IApplicationUserManager
    {
        int ActiveUserCount();
        ApplicationUserDetail Login(ApplicationUserLogin applicationUserLogin);
        //int ManageInvalidAttempt(string emailAddress);
        string EditProfile(EditProfileApplicationUser editProfileApplicationUser);
        string ChangePassword(int id, string oldPassword, string newPassword);
        ApplicationUserResponse GetApplicationUsers(int pageNo, string search);
        ApplicationUserDetail GetApplicationUserById(int id);
        ApplicationUserDetail GetApplicationUserByEmailAddress(string emailAddress);
        int Create(AddApplicationUserRequest applicationUserRequest);
        string Update(UpdateApplicationUserRequest applicationUserRequest);
        
        string UpdateActiveStatus(int id);
        string Delete(int id);
        

        
    }
}
