using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.BookPlace;

namespace LCMS.ServiceProxy.BookPlace
{
    public interface IBookPlaceServiceProxy
    {
        List<BookPlaceDetail> GetBookPlacesByCatalog(int catalogId);
    }
}
