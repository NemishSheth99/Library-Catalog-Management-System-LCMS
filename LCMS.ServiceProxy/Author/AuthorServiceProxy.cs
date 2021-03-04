using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.Author;

namespace LCMS.ServiceProxy.Author
{
    public class AuthorServiceProxy:ServiceProxyBase,IAuthorServiceProxy
    {
        public AuthorServiceProxy()
        {
            ServiceUrlPrefix = "api/AuthorAPI";
        }

        public string Create(AuthorDetail authorDetail)
        {
            return MakeRequest<string, AuthorDetail>("AddAuthor", ServiceRequestType.Post, authorDetail);
        }

        public string Delete(int bookCatalogId)
        {
            return MakeRequest<string, int>("DeleteAuthor/" + bookCatalogId, ServiceRequestType.Delete, 0);
        }
    }
}
