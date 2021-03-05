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

        [Route("api/AuthorAPI/GetAuthorByBookCatalog")]
        [HttpGet]
        public IHttpActionResult GetAuthorByBookCatalog(int bookCatalogId)
        {
            return Ok(_authorManager.GetAuthorByBookcatalog(bookCatalogId));
        }

        [Route("api/AuthorAPI/AddAuthor")]
        [HttpPost]
        public IHttpActionResult AddAuthor(AuthorDetail authorDetail)
        {
            return Ok( _authorManager.Create(authorDetail));
        }

        [Route("api/AuthorAPI/DeleteAuthor")]
        [HttpPost]
        public IHttpActionResult DeleteAuthor(AuthorDetail authorDetail)
        {
            return Ok(_authorManager.DeleteBookAuthors(authorDetail));
        }

        [Route("api/AuthorAPI/DeleteBookAuthor/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteBookAuthor(int id)
        {
            return Ok(_authorManager.Delete(id));
        }
    }
}
