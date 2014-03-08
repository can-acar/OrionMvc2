using System;
using System.Collections.Generic;
using System.Text;
using AspHttpContext = System.Web.HttpContext;
using System.Web;

namespace OrionMvc.Web
{
    public interface IHttpResponse
    {
        string Body
        {
            get;
            set;
        }

        OrionMvc.Web.IHttpResponseHeaders Headers
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets HTTP status code.
        /// </summary>
        /// <value>HTTP status code.</value>
        OrionMvc.Web.HttpStatusCode StatusCode
        {
            get;
            set;
        }

        void Write(string content);

        void Init(HttpContext mvcContext, AspHttpContext aspContext);

        void StreamFile(string filePath);
    }
}
