using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LCMS.WebAPI.Controllers
{
    public class TransactionHistoryAPIController : ApiController
    {
        // GET: api/TransactionHistoryAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TransactionHistoryAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TransactionHistoryAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TransactionHistoryAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TransactionHistoryAPI/5
        public void Delete(int id)
        {
        }
    }
}
