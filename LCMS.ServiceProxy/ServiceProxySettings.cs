using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCMS.ServiceProxy
{
    public static class ServiceProxySettings
    {
        #region Properties

        /// <summary>
        /// Gets or sets the service base URL.
        /// </summary>
        /// <value>
        /// The service base URL.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        public static string ServiceBaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the service timeout.
        /// </summary>
        /// <value>
        /// The service timeout.
        /// </value>
        public static double? ServiceTimeout { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the settings.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="timeout">The timeout.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#")]
        public static void SetSettings(string baseUrl, double timeout)
        {
            ServiceBaseUrl = baseUrl;
            ServiceTimeout = timeout;
        }

        #endregion
    }
}
