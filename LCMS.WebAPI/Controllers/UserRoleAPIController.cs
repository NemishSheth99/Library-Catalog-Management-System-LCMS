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

        // GET: api/UserRoleAPI
        public IHttpActionResult Get()
        {
            return Ok();
        }

        // GET: api/UserRoleAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserRoleAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserRoleAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserRoleAPI/5
        public void Delete(int id)
        {
        }
    }
}
