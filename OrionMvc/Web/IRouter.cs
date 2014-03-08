using System;
using System.Collections.Generic;
using System.Web;

namespace OrionMvc.Web
{
    public interface IRouter : IDictionary<string, object>
    {
        void Connect(string path, object _default);
        void Connect(string path, object _default, object rule);
        void Dispatch(HttpContext context);

        void Match(string url);

        RouteMeta Meta
        {
            set;
            get;
        }


    }
}
