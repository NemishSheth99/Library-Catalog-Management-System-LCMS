﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Core;
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

        public Result Create(AddApplicationUserRequest applicationUserRequest)
        {
            return MakeRequest<Result, AddApplicationUserRequest>("AddUser", ServiceRequestType.Post, applicationUserRequest);
        }

        public string Update(UpdateApplicationUserRequest applicationUserRequest)
        {
            return MakeRequest<string, UpdateApplicationUserRequest>("UpdateUser", ServiceRequestType.Put, applicationUserRequest);
        }

        public string Delete(int id)
        {
            //var queryParam = new Dictionary<string, string>
            //{
            //    {"id", id.ToString(CultureInfo.InvariantCulture)}
            //};
            //return GetRequest<string>("DeleteUser",  queryParam);
            return MakeRequest<string, int>("DeleteUser/"+id, ServiceRequestType.Delete, 0);
        }

        public string UpdateActiveStatus(int id)
        {
            return MakeRequest<string, int>("ChangeUserActivity/"+id, ServiceRequestType.Put, id);
        }
    }
}
