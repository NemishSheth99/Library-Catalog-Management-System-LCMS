using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Core;
using LCMS.Models.ApplicationUser;

namespace LCMS.ServiceProxy.ApplicationUser
{
    public interface IApplicationUserServiceProxy
    {
        ApplicationUserDetail Login(ApplicationUserLogin applicationUserLogin);
        ApplicationUserResponse GetApplicationUsers(int pageNo, string search);
        ApplicationUserDetail GetApplicationUserById(int id);
        Result Create(AddApplicationUserRequest applicationUserRequest);
        Result Update(UpdateApplicationUserRequest applicationUserRequest);
        string EditProfile(EditProfileApplicationUser editProfileApplicationUser);
        string Delete(int id);
        string UpdateActiveStatus(int id);
        string ChangePassword(ChangePasswordApplicationUser changePasswordApplicationUser);
        int ActiveUserCount();
    }
}
