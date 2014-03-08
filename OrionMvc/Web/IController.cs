using System;
using System.Web;

namespace OrionMvc.Web
{
    public interface IController
    {
        void Execute(HttpContext context, RouteMeta routeData);

        void Render(HttpContext context, string View);

        HttpContext Context
        {
            get;
            set;
        }


        new dynamic ViewBag
        {
            set;
            get;
        }

        string Name
        {
            get;
            set;
        }

        HttpRequest Request { get; set; }
    }
}
