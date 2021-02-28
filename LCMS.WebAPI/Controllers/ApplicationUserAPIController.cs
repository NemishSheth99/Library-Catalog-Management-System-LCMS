using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using LCMS.BAL.Interface;
using LCMS.Models.ApplicationUser;

namespace LCMS.WebAPI.Controllers
{
    public class ApplicationUserAPIController : ApiController
    {
        private readonly IApplicationUserManager _applicationUserManager;

        public ApplicationUserAPIController(IApplicationUserManager applicationUserManager)
        {
            _applicationUserManager = applicationUserManager;
        }

        [Route("api/ApplicationUserAPI/LoginUser")]
        [HttpPost]
        public IHttpActionResult LoginUser(ApplicationUserLogin applicationUserLogin)
        {
            ApplicationUserDetail applicationUserDetail = _applicationUserManager.Login(applicationUserLogin);
            if (applicationUserDetail.EmailAddress != null)
            {               
                return Ok(applicationUserDetail);
            }
            else
            {                
                return Ok("No User Found!!!");
            }
        }

        [Route("api/ApplicationUserAPI/GetApplicationUsers")]
        [HttpGet]
        public IHttpActionResult GetApplicationUsers()
        {
            return Ok(_applicationUserManager.GetApplicationUsers());
        }

        [Route("api/ApplicationUserAPI/GetUser")]
        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            return Ok(_applicationUserManager.GetApplicationUserById(id));
        }

        [Route("api/ApplicationUserAPI/AddUser")]
        [HttpPost]
        public IHttpActionResult AddUser(AddApplicationUserRequest applicationUserRequest)
        {
            ApplicationUserDetail applicationUserDetail = _applicationUserManager.GetApplicationUserByEmailAddress(applicationUserRequest.EmailAddress);
            int result;
            if (applicationUserDetail.EmailAddress == null)
            {
                result = _applicationUserManager.Create(applicationUserRequest);
                return Ok(result);
            }
            else
                return BadRequest("Email Address Already Exist!!!");
        }

        [Route("api/ApplicationUserAPI/UpdateUser")]
        [HttpPut]
        public IHttpActionResult UpdateUser(UpdateApplicationUserRequest applicationUserRequest)
        {
            return Ok(_applicationUserManager.Update(applicationUserRequest));
        }

        [Route("api/ApplicationUserAPI/DeleteUser/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            return Ok(_applicationUserManager.Delete(id));
        }
    }
}
