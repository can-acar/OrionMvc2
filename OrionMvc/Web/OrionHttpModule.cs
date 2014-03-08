using System;
using System.Collections.Generic;
using System.Web;

namespace OrionMvc.Web
{
    public class OrionHttpModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(BeginRequest);
            context.PreRequestHandlerExecute += new EventHandler(PreRequestHandlerExecute);
            context.EndRequest += new EventHandler(EndRequest);
            context.AuthorizeRequest += new EventHandler(AuthorizeRequest);
        }




        private void BeginRequest(object sender, EventArgs e)
        {
        }

        private void EndRequest(object sender, EventArgs e)
        {
        }

        private void AuthorizeRequest(object sender, EventArgs e)
        {
            var context = ((HttpApplication)sender).Context;

            if (context.Request.RawUrl.Contains(".bspx"))
            {
                var url = context.Request.RawUrl.Replace(".bspx", ".aspx");
                context.RewritePath(url);
            }
        }

        private void PreRequestHandlerExecute(object sender, EventArgs e)
        {
            var context = ((HttpApplication)sender).Context;

            if (context.Items["originalUrl"] != null)
            {
                context.RewritePath((string)context.Items["originalUrl"]);
            }
        }
    }
}
