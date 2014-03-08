using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Web;
using System.Web.Compilation;
using System.Web.UI;



namespace OrionMvc.Web
{
    //Page, IView
    public class View : IView
    {
        private static dynamic viewBag;
        private RazorViewEngine _engine { set; get; }
        public View()
        {
            this._engine = new RazorViewEngine();
        }



        public View(string viewname = null, IController controller = null)
        {
            string _viewfolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("View\\{0}", controller.Name));
            _engine = new RazorViewEngine(_viewfolder, viewname);
        }


        public string Render(HttpContext context, IController controller, string viewName)
        {
            viewBag = controller.ViewBag;


            this._engine.ViewFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("View\\{0}", controller.Name)); //string.Format("View/{0}", controller.Name);
            return this._engine.Parse<ViewData>(viewName, ViewBag);
        }

        public string Render_(HttpContext context, IController controller, string path)
        {
            viewBag = controller.ViewBag;

            string _path = string.Format("~View/{0}/{1}.aspx", controller.Name, path);

            var objContentPage = BuildManager.CreateInstanceFromVirtualPath(_path.ToString(), typeof(Page)) as View;

            StringWriter sw = new StringWriter();

            //objContentPage.AppRelativeVirtualPath = _path.ToString();

            //context.Server.Execute(objContentPage, sw, false);

            return sw.GetStringBuilder().ToString();

        }

        public object PartialRender(HttpContext context, IController controller, string path)
        {
            viewBag = controller.ViewBag;

            string _path = string.Format("~/View/{0}/{1}.aspx", controller.Name, path);

            var objContentPage = BuildManager.CreateInstanceFromVirtualPath(_path.ToString(), typeof(Page)) as View;

            StringWriter sw = new StringWriter();

            //objContentPage.AppRelativeVirtualPath = _path.ToString();

            //context.Server.Execute(objContentPage, sw, false);


            sw.GetStringBuilder().ToString();

            return viewBag;
        }

        public dynamic RenderLayout(HttpContext httpContext, Controller controller, string ViewName)
        {
            viewBag = controller.ViewBag;
            this._engine.ViewFolder = controller.Name;

            return this._engine.Parse<ViewData>(ViewName, viewBag);
        }



        public string GetPathView(IController controller, string path)
        {
            var _path = string.Empty;
            return _path;
        }


        public static dynamic ViewBag
        {

            get { return viewBag; }
        }



    }
}
