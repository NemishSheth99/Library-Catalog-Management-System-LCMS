﻿using System;
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

        [Route("api/BookCatalogAPI/GetBookCatalogs")]
        [HttpGet]
        public IHttpActionResult GetBookCatalogs()
        {
            return Ok(_bookCatalogManager.GetBookCatalogs());
        }

    }
}
