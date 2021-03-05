using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.Author;
using System.Globalization;

namespace LCMS.ServiceProxy.Author
{
    public class AuthorServiceProxy:ServiceProxyBase,IAuthorServiceProxy
    {
        public AuthorServiceProxy()
        {
            ServiceUrlPrefix = "api/AuthorAPI";
        }

        public List<AuthorDetail> GetAuthorsByCatalog(int bookCatalogId)
        {
            var queryParam = new Dictionary<string, string>
            {
                {"bookCatalogId", bookCatalogId.ToString(CultureInfo.InvariantCulture)}
            };
            return GetRequest<List<AuthorDetail>>("GetAuthorByBookCatalog", queryParam);
        }

        public string Create(AuthorDetail authorDetail)
        {
            return MakeRequest<string, AuthorDetail>("AddAuthor", ServiceRequestType.Post, authorDetail);
        }

        public string DeleteAuthor(AuthorDetail authorDetail)
        {
            return MakeRequest<string, AuthorDetail>("DeleteAuthor", ServiceRequestType.Post, authorDetail);
        }

        public string Delete(int bookCatalogId)
        {
            return MakeRequest<string, int>("DeleteBookAuthor/" + bookCatalogId, ServiceRequestType.Delete, 0);
        }
    }
}
