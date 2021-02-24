using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.UserRole;

namespace LCMS.ServiceProxy.UserRole
{
    public class UserRoleServiceProxy: ServiceProxyBase,IUserRoleServiceProxy
    {
        public UserRoleServiceProxy()
        {
            ServiceUrlPrefix = "api/UserRoleAPI";
        }

        public List<UserRoleDetail> GetUserRoleDetails()
        {
            var queryParam = new Dictionary<string, string>();
            return GetRequest<List<UserRoleDetail>>("GetUserRoles", queryParam);
        }

        public int GetRoleId(string role)
        {
            var queryParam = new Dictionary<string, string>
            {
                {"role", role.ToString(CultureInfo.InvariantCulture)}
            };
            return GetRequest<int>("GetUserRole", queryParam);
        }
    }
}
