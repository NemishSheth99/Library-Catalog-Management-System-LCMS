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
        ApplicationUser Login(ApplicationUser applicationUser);
        List<ApplicationUser> GetApplicationUsers();
        ApplicationUser GetApplicationUserById(int id);
        ApplicationUser GetApplicationUserByEmail(string emailAddress);
        int Create(ApplicationUser applicationUser);
        string Update(ApplicationUser applicationUser);
        string UpdateActiveStatus(int id, string status);
        string Delete(int id);
        string ChangePassword(int id, string passwprd);
    }
}
