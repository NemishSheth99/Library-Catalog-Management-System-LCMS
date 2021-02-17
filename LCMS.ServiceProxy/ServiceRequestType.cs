using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCMS.ServiceProxy
{
    public enum ServiceRequestType
    {
        /// <summary>
        /// The get
        /// </summary>
        Get = 1,
        /// <summary>
        /// The put
        /// </summary>
        Put = 2,
        /// <summary>
        /// The post
        /// </summary>
        Post = 3,
        /// <summary>
        /// The delete
        /// </summary>
        Delete = 4
    }
}
