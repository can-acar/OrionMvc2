using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspHttpContext = System.Web.HttpContext;

namespace OrionMvc.Web
{
    public interface IHttpRequest
    {
        string FullPath { get;
            set; }

        string Path { get;
            set; }

        void Init(HttpContext mvcContext, AspHttpContext aspContext);
    }
}
