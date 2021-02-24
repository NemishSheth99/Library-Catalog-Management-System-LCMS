using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LCMS.BAL.Interface;

namespace LCMS.WebAPI.Controllers
{
    public class BookCatalogAPIController : ApiController
    {
        private readonly IBookCatalogManager _bookCatalogManager;        

        public BookCatalogAPIController(IBookCatalogManager bookCatalogManager)
        {
            _bookCatalogManager = bookCatalogManager;
        }

        // GET: api/BookCatalogAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BookCatalogAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BookCatalogAPI
        //public IHttpActionResult Post(BookCatalog bookCatalog)
        //{
        //    return Ok();
        //}

        // PUT: api/BookCatalogAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BookCatalogAPI/5
        public void Delete(int id)
        {
        }
    }
}
