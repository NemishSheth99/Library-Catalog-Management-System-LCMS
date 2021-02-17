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
            try
            {
                return Ok(_applicationUserRoleManager.GetApplicationUserRoleDetail(userId));
            }
            catch (Exception ex)
            {
                //log.Error("Exception : " + ex);
                return NotFound();
            }

        }
    }
}
