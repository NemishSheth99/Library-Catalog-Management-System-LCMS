using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LCMS.BAL.Interface;
using LCMS.Models;

namespace LCMS.WebAPI.Controllers
{
    public class UserRoleAPIController : ApiController
    {
        private readonly IUserRoleManager _userRoleManager;

        public UserRoleAPIController(IUserRoleManager userRoleManager)
        {
            _userRoleManager = userRoleManager;
        }

        [Route("api/UserRoleAPI/GetUserRoles")]
        [HttpGet]
        public IHttpActionResult GetUserRoles()
        {
            return Ok(_userRoleManager.GetUserRoleDetails());
        }

        [Route("api/UserRoleAPI/GetUserRole")]
        [HttpGet]
        public IHttpActionResult GetUserRole(string role)
        {
            return Ok(_userRoleManager.GetRoleId(role));
        }
    }
}
