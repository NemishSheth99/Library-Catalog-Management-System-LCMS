using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LCMS.BAL.Interface;
using LCMS.Models.Author;

namespace LCMS.WebAPI.Controllers
{
    public class AuthorAPIController : ApiController
    {
        private readonly IAuthorManager _authorManager;

        public AuthorAPIController(IAuthorManager authorManager)
        {
            _authorManager = authorManager;
        }

        [Route("api/AuthorAPI/AddAuthor")]
        [HttpPost]
        public IHttpActionResult AddAuthor(AuthorDetail authorDetail)
        {
            return Ok( _authorManager.Create(authorDetail));
        }

        [Route("api/AuthorAPI/DeleteAuthor/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteAuthor(int id)
        {
            return Ok(_authorManager.Delete(id));
        }
    }
}
