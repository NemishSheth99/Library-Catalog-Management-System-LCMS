using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.ApplicationUser;

namespace LCMS.ServiceProxy.ApplicationUser
{
    public interface IApplicationUserServiceProxy
    {
        ApplicationUserDetail Login(ApplicationUserLogin applicationUserLogin);
        List<ApplicationUserDetail> GetApplicationUsers();
        ApplicationUserDetail GetApplicationUserById(int id);
        string Create(AddApplicationUserRequest applicationUserRequest);
        string Update(AddApplicationUserRequest applicationUserRequest);
    }
}
