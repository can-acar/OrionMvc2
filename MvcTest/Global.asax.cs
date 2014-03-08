using OrionMvc.Web;
using System;
using System.Collections.Generic;
using System.Linq;




namespace MvcTest
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //System.Web.Razor.RazorCodeLanguage.Languages.Add(
            //    "cshtml", new CSharpRazorCodeLanguage());
            var App = OrionMvc.Application.GetInstance();
            AppInstance(App.Router);
            //HostingEnvironment.RegisterVirtualPathProvider(new RazorVirtualPathProvider());

           
            
        }
        private void AppInstance(IRouter router)
        {
            router.Connect(string.Empty, new
            {
                controller = "Home",
                action = "Index"
            });
        }
    }
}
