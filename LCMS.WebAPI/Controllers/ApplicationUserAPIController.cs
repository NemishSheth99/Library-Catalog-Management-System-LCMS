using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using LCMS.Core;
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
            return Ok(applicationUserDetail);
        }

        [Route("api/ApplicationUserAPI/GetApplicationUsers")]
        [HttpGet]
        public IHttpActionResult GetApplicationUsers(int pageNo, string search)
        {
            return Ok(_applicationUserManager.GetApplicationUsers(pageNo, search));
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
            Result rs = new Result();
            if (applicationUserDetail.EmailAddress == null)
            {
                int x = _applicationUserManager.Create(applicationUserRequest);
                rs.Status = "Success";
                rs.Message = "User successfully Added";
                rs.Data = x.ToString();
            }
            else
            {
                rs.Status = "Fail";
                rs.Message = "Email Address Already Exist!!!";
            }
            return Ok(rs);
        }

        [Route("api/ApplicationUserAPI/UpdateUser")]
        [HttpPut]
        public IHttpActionResult UpdateUser(UpdateApplicationUserRequest applicationUserRequest)
        {
            ApplicationUserDetail applicationUserDetail = _applicationUserManager.GetApplicationUserByEmailAddress(applicationUserRequest.EmailAddress);
            Result rs = new Result();
            if (applicationUserDetail.Id == applicationUserDetail.Id)
            {
                if (applicationUserDetail.EmailAddress == applicationUserRequest.EmailAddress || applicationUserDetail.EmailAddress == null)
                {
                    string result = _applicationUserManager.Update(applicationUserRequest);
                    rs.Status = "Success";
                    rs.Message = "User successfully Updated";
                }
            }
            else
            {
                rs.Status = "Fail";
                rs.Message = "Email Address Already Exist!!!";
            }
            return Ok(rs);
        }

        [Route("api/ApplicationUserAPI/EditProfile")]
        [HttpPut]
        public IHttpActionResult EditProfile(EditProfileApplicationUser editProfileApplicationUser)
        {
            return Ok(_applicationUserManager.EditProfile(editProfileApplicationUser));
        }

        [Route("api/ApplicationUserAPI/DeleteUser/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            return Ok(_applicationUserManager.Delete(id));
        }

        [Route("api/ApplicationUserAPI/ChangeUserActivity/{id}")]
        [HttpPut]
        public IHttpActionResult ChangeUserActivity(int id)
        {
            return Ok(_applicationUserManager.UpdateActiveStatus(id));
        }

        [Route("api/ApplicationUserAPI/ChangePassword")]
        [HttpPut]
        public IHttpActionResult ChangePassword(ChangePasswordApplicationUser changePasswordApplicationUser)
        {
            return Ok(_applicationUserManager.ChangePassword(changePasswordApplicationUser.Id, changePasswordApplicationUser.OldPassword, changePasswordApplicationUser.NewPassword));
        }

        [Route("api/ApplicationUserAPI/ActiveUserCount")]
        [HttpGet]
        public IHttpActionResult ActiveUserCount()
        {
            return Ok(_applicationUserManager.ActiveUserCount());
        }
    }
}
