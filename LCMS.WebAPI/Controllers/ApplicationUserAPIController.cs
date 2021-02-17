using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            try
            {
                return Ok(_applicationUserManager.Login(applicationUserLogin));
            }
            catch (Exception ex)
            {
                //log.Error("Exception : " + ex);
                return NotFound();
            }

        }

        [Route("api/ApplicationUserAPI/GetApplicationUsers")]
        [HttpGet]
        public IHttpActionResult GetApplicationUsers()
        {
            try
            {
                return Ok(_applicationUserManager.GetApplicationUsers());
            }
            catch (Exception ex)
            {
                //log.Error("Exception : " + ex);
                return NotFound();
            }

        }

        [Route("api/ApplicationUserAPI/GetUser")]
        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            try
            {
                return Ok(_applicationUserManager.GetApplicationUserById(id));
            }
            catch (Exception ex)
            {
                //log.Error("Exception : " + ex);
                return NotFound();
            }

        }

        [Route("api/ApplicationUserAPI/AddUser")]
        [HttpPost]
        public IHttpActionResult AddUser(AddApplicationUserRequest applicationUserRequest)
        {
            try
            {
                return Ok(_applicationUserManager.Create(applicationUserRequest));
            }
            catch (Exception ex)
            {
                //log.Error("Exception : " + ex);
                return NotFound();
            }

        }

        [Route("api/ApplicationUserAPI/UpdateUser")]
        [HttpPost]
        public IHttpActionResult UpdateUser(AddApplicationUserRequest applicationUserRequest)
        {
            try
            {
                return Ok(_applicationUserManager.Update(applicationUserRequest));
            }
            catch (Exception ex)
            {
                //log.Error("Exception : " + ex);
                return NotFound();
            }

        }
    }
}
