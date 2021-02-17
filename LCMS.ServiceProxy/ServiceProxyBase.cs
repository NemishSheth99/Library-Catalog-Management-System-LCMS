using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LCMS.ServiceProxy
{
    public abstract class ServiceProxyBase
    {
        #region Properties

        /// <summary>
        /// Gets or sets the service URL prefix.
        /// </summary>
        /// <value>
        /// The service URL prefix.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        protected string ServiceUrlPrefix { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the request.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="actionPath">The action path.</param>
        /// <param name="queryStringParameters">The query string parameters.</param>
        /// <returns>
        /// Returns T result
        /// </returns>
        protected TResult GetRequest<TResult>(string actionPath, Dictionary<string, string> queryStringParameters)
        {
            return GetRequest<TResult>(actionPath, queryStringParameters, null);
        }

        /// <summary>
        /// Gets the request.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="actionPath">The action path.</param>
        /// <param name="queryStringParameters">The query string parameters.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>
        /// Returns T result
        /// </returns>
        protected TResult GetRequest<TResult>(string actionPath, Dictionary<string, string> queryStringParameters, double? timeout)
        {
            var url = CreateUrl(actionPath);
            if (queryStringParameters != null && queryStringParameters.Count > 0)
            {
                var queryString = new StringBuilder();
                foreach (var item in queryStringParameters)
                {
                    if (queryString.Length > 0)
                    {
                        queryString.Append("&");
                    }
                    queryString.Append(string.Format(CultureInfo.InvariantCulture, "{0}={1}", item.Key, WebUtility.UrlEncode(item.Value)));
                }
                url += "?" + queryString;
            }
            return ProcessRequest<TResult, object>(url, ServiceRequestType.Get, null, timeout);
        }

        /// <summary>
        /// Makes the request.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="T">The type of the request data.</typeparam>
        /// <param name="actionPath">The action path.</param>
        /// <param name="requestType">Type of the request.</param>
        /// <param name="data">The data.</param>
        /// <returns>
        /// Returns T result
        /// </returns>
        protected TResult MakeRequest<TResult, T>(string actionPath, ServiceRequestType requestType, T data)
        {
            return MakeRequest<TResult, T>(actionPath, requestType, data, null);
        }

        /// <summary>
        /// Makes the request.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="T">The type of the request data.</typeparam>
        /// <param name="actionPath">The action path.</param>
        /// <param name="requestType">Type of the request.</param>
        /// <param name="data">The data.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>
        /// Returns T result
        /// </returns>
        /// <exception cref="InvalidOperationException">Invalid request type</exception>
        protected TResult MakeRequest<TResult, T>(string actionPath, ServiceRequestType requestType, T data, double? timeout)
        {
            switch (requestType)
            {
                case ServiceRequestType.Get:
                    throw new InvalidOperationException("Invalid request type");
                default:
                    return ProcessRequest<TResult, T>(CreateUrl(actionPath), requestType, data, timeout);
            }
        }

        /// <summary>
        /// Creates the URL.
        /// </summary>
        /// <param name="actionPath">The action path.</param>
        /// <returns>
        /// Returns URL
        /// </returns>
        private string CreateUrl(string actionPath)
        {
            var urlPart = string.Empty;
            if (!string.IsNullOrWhiteSpace(ServiceUrlPrefix))
            {
                urlPart += ServiceUrlPrefix.TrimEnd("/".ToCharArray()) + "/";
            }
            urlPart += actionPath;
            return urlPart;
        }

        /// <summary>
        /// Processes the request.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="T">The type of the request data.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="requestType">Type of the request.</param>
        /// <param name="data">The data.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>
        /// Returns T result
        /// </returns>
        /// <exception cref="InvalidEnumArgumentException">requestType</exception>
        private static TResult ProcessRequest<TResult, T>(string url, ServiceRequestType requestType, T data, double? timeout)
        {
            using (var client = new HttpClient())
            {
                var serviceBaseAddress = GetServiceBaseAddress();
                var baseTimeout = GetServiceTimeout();
                if (timeout.HasValue)
                {
                    baseTimeout = timeout.Value;
                }
                client.BaseAddress = new Uri(serviceBaseAddress);
                client.Timeout = TimeSpan.FromSeconds(baseTimeout);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.ConnectionClose = true;

                Task<HttpResponseMessage> response;
                switch (requestType)
                {
                    case ServiceRequestType.Put:
                        response = client.PutAsJsonAsync(url, data);
                        break;
                    case ServiceRequestType.Post:
                        response = client.PostAsJsonAsync(url, data);
                        break;
                    case ServiceRequestType.Delete:
                        response = client.DeleteAsync(url);
                        break;
                    case ServiceRequestType.Get:
                        response = client.GetAsync(url);
                        break;
                    default:
                        throw new InvalidEnumArgumentException(nameof(requestType), (int)requestType, typeof(ServiceRequestType));
                }

                using (response)
                {
                    return ProcessResponse<TResult>(response);
                }
            }
        }

        /// <summary>
        /// Processes the response.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="response">The response.</param>
        /// <returns>
        /// Returns T result
        /// </returns>
        /// <exception cref="AuthenticationException">Access Denied. Web Api request authentication failed.</exception>
        /// <exception cref="System.Web.HttpException"></exception>
        private static TResult ProcessResponse<TResult>(Task<HttpResponseMessage> response)
        {
            var result = response.Result;
            switch (result.StatusCode)
            {
                case HttpStatusCode.Created:
                case HttpStatusCode.OK:
                    {
                        return result.Content.ReadAsAsync<TResult>().Result;
                    }
                case HttpStatusCode.NotFound:
                case HttpStatusCode.NoContent:
                    {
                        return default(TResult);
                    }
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.Unauthorized:
                    {
                        throw new Exception("Access denied. Web API request authentication failed.");
                    }
                default:
                    {
                        var responseBody = result.Content.ReadAsStringAsync().Result;
                        throw new System.Web.HttpException((int)result.StatusCode, responseBody);
                    }
            }
        }

        /// <summary>
        /// Gets the service base address.
        /// </summary>
        /// <returns>
        /// Returns service base address
        /// </returns>
        private static string GetServiceBaseAddress()
        {
            var serviceBaseAddress = ServiceProxySettings.ServiceBaseUrl;
            return serviceBaseAddress.TrimEnd("/".ToCharArray()) + "/";
        }

        /// <summary>
        /// Gets the service timeout.
        /// </summary>
        /// <returns>
        /// Returns service timeout
        /// </returns>
        private static double GetServiceTimeout()
        {
            double timeout;
            const double defaultTimeout = 300;
            if (ServiceProxySettings.ServiceTimeout.HasValue)
            {
                timeout = ServiceProxySettings.ServiceTimeout.Value;
            }
            else
            {
                timeout = defaultTimeout;
            }
            return timeout;
        }

        #endregion
    }
}
