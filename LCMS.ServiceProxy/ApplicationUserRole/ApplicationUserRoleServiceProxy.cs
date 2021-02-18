using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.ApplicationUserRole;

namespace LCMS.ServiceProxy.ApplicationUserRole
{
    public class ApplicationUserRoleServiceProxy : ServiceProxyBase,IApplicationUserRoleServiceProxy
    {
        public ApplicationUserRoleServiceProxy()
        {
            ServiceUrlPrefix = "api/ApplicationUserRoleAPI";
        }

        public ApplicationUserRoleDetail GetRoleDetail(int userId)
        {
            var queryParam = new Dictionary<string, string>
            {
                {"userId", userId.ToString(CultureInfo.InvariantCulture)}
            };
            return GetRequest<ApplicationUserRoleDetail>("GetUserRole", queryParam);
        }

        public string Create(AddApplicationUserRoleRequest applicationUserRoleRequest)
        {
            return MakeRequest<string, AddApplicationUserRoleRequest>("AddApplicationUserRole", ServiceRequestType.Post, applicationUserRoleRequest);
        }
    }
}
