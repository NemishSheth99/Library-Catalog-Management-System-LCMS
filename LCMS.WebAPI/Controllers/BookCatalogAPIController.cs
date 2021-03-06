﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LCMS.BAL.Interface;
using LCMS.Models.BookCatalog;

namespace LCMS.WebAPI.Controllers
{
    public class BookCatalogAPIController : ApiController
    {
        private readonly IBookCatalogManager _bookCatalogManager;

        public BookCatalogAPIController(IBookCatalogManager bookCatalogManager)
        {
            _bookCatalogManager = bookCatalogManager;
        }

        [Route("api/BookCatalogAPI/GetBookCatalogs")]
        [HttpGet]
        public IHttpActionResult GetBookCatalogs(int pageNo, string search)
        {
            return Ok(_bookCatalogManager.GetBookCatalogs(pageNo,search));
        }

        [Route("api/BookCatalogAPI/GetBookCatalog")]
        [HttpGet]
        public IHttpActionResult GetBookCatalog(int id)
        {
            return Ok(_bookCatalogManager.GetBookCatalogById(id));
        }

        [Route("api/BookCatalogAPI/AddBookCatalog")]
        [HttpPost]
        public IHttpActionResult AddBookCatalog(AddBookCatalog addBookCatalog)
        {
            int x = _bookCatalogManager.Create(addBookCatalog);
            return Ok(x);
        }

        [Route("api/BookCatalogAPI/UpdateBookCatalog")]
        [HttpPut]
        public IHttpActionResult UpdateBookCatalog(AddBookCatalog addBookCatalog)
        {
            int x = _bookCatalogManager.Update(addBookCatalog);
            return Ok(x);
        }

        [Route("api/BookCatalogAPI/DeleteBookCatalog/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteBookCatalog(int id)
        {
            return Ok(_bookCatalogManager.Delete(id));
        }

        [Route("api/BookCatalogAPI/ActiveCatalogCount")]
        [HttpGet]
        public IHttpActionResult ActiveCatalogCount()
        {
            return Ok(_bookCatalogManager.ActiveCatalogCount());
        }

    }
}
