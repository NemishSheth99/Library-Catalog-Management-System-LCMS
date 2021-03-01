using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LCMS.BAL.Interface;
using LCMS.Models.ApplicationUserRole;

namespace LCMS.WebAPI.Controllers
{
    public class ApplicationUserRoleAPIController : ApiController
    {
        private readonly IApplicationUserRoleManager _applicationUserRoleManager;

        public ApplicationUserRoleAPIController(IApplicationUserRoleManager applicationUserRoleManager)
        {
            _applicationUserRoleManager = applicationUserRoleManager;
        }

        [Route("api/ApplicationUserRoleAPI/GetUserRole")]
        [HttpGet]
        public IHttpActionResult GetUserRole(int userId)
        {
            return Ok(_applicationUserRoleManager.GetApplicationUserRoleDetail(userId));
        }

        [Route("api/ApplicationUserRoleAPI/AddApplicationUserRole")]
        [HttpPost]
        public IHttpActionResult AddApplicationUserRole(AddApplicationUserRoleRequest applicationUserRoleRequest)
        {
            return Ok(_applicationUserRoleManager.Create(applicationUserRoleRequest));
        }

        [Route("api/ApplicationUserRoleAPI/UpdateApplicationUserRole")]
        [HttpPut]
        public IHttpActionResult UpdateApplicationUserRole(AddApplicationUserRoleRequest applicationUserRoleRequest)
        {
            return Ok(_applicationUserRoleManager.Update(applicationUserRoleRequest));
        }
    }
}
