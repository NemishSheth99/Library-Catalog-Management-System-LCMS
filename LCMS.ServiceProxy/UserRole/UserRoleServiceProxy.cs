using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCMS.ServiceProxy.UserRole
{
    public class UserRoleServiceProxy: ServiceProxyBase,IUserRoleServiceProxy
    {
        public UserRoleServiceProxy()
        {
            ServiceUrlPrefix = "api/UserRoleAPI";
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
