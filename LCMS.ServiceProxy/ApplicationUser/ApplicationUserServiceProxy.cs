using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.ApplicationUser;

namespace LCMS.ServiceProxy.ApplicationUser
{
    public class ApplicationUserServiceProxy : ServiceProxyBase, IApplicationUserServiceProxy
    {
        public ApplicationUserServiceProxy()
        {
            ServiceUrlPrefix = "api/ApplicationUserAPI";
        }        

        public ApplicationUserDetail Login(ApplicationUserLogin applicationUserLogin)
        {
            return MakeRequest<ApplicationUserDetail,ApplicationUserLogin>("LoginUser", ServiceRequestType.Post, applicationUserLogin);
        }

        public List<ApplicationUserDetail> GetApplicationUsers()
        {
            var queryParam = new Dictionary<string, string>();
            return GetRequest<List<ApplicationUserDetail>>("GetApplicationUsers",queryParam);
        }

        public ApplicationUserDetail GetApplicationUserById(int id)
        {
            var queryParam = new Dictionary<string, string>
            {
                {"id", id.ToString(CultureInfo.InvariantCulture)}
            };
            return GetRequest<ApplicationUserDetail>("GetUser", queryParam);
        }

        public string Create(AddApplicationUserRequest applicationUserRequest)
        {
            return MakeRequest<string, AddApplicationUserRequest>("AddUser", ServiceRequestType.Post, applicationUserRequest);
        }

        public string Update(AddApplicationUserRequest applicationUserRequest)
        {
            return MakeRequest<string, AddApplicationUserRequest>("UpdateUser", ServiceRequestType.Put, applicationUserRequest);
        }
    }
}
