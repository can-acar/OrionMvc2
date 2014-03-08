namespace OrionMvc.Web
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Microsoft.CSharp;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Razor;
    using System.Web.UI;
    using RazorEngine;
    using RazorEngine.Configuration;
    using RazorEngine.Text;
    using RazorEngine.Templating;

    public class RazorViewEngine : Page, IViewEngine
    {
        private static readonly Dictionary<string, string> viewCache = new Dictionary<string, string>();

        public string ViewFolder { set; get; }
        public string LayoutViewName { set; get; }

        public RazorViewEngine()//:this("View","_layout")
        {

        }

        public RazorViewEngine(string viewFolder, string layoutViewName)
        {
            ViewFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, viewFolder);
            LayoutViewName = layoutViewName;

            if (!Directory.Exists(ViewFolder))
                throw new DirectoryNotFoundException("The view folder specified cannot be located.\r\nThe folder should be in the root of your application which was resolved as " + AppDomain.CurrentDomain.BaseDirectory);
        }

        public string RenderView(string viewFolder, string layoutViewName, string ViewName)
        {
            ViewFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, viewFolder);
            LayoutViewName = layoutViewName;

            if (!Directory.Exists(ViewFolder))
                throw new DirectoryNotFoundException("The view folder specified cannot be located.\r\nThe folder should be in the root of your application which was resolved as " + AppDomain.CurrentDomain.BaseDirectory);
            return this.Parse<object>(ViewName, null);

        }

        private FileInfo FindView(string view)
        {
            var file = new FileInfo(Path.Combine(ViewFolder, view + ".cshtml"));
            if (!file.Exists)
                file = null;

            return file;
        }

        public string Parse(string viewName)
        {
            return Parse<object>(viewName, null);
        }

        public string Parse<T>(string viewName, T model)
        {
            //// viewName = viewName.ToLower();
            //  dynamic content  = null;
            // if (!viewCache.ContainsKey(viewName))
            // {
            //     var layout = FindView(LayoutViewName);
            //     var view = FindView(viewName);

            //     if (!view.Exists)
            //         throw new FileNotFoundException(String.Format("No view with the name '{0}' was found in the views folder ({1}).\r\nEnsure that you have a file with that name and an extension of either cshtml or vbhtml", view, ViewFolder));

            //   content = File.ReadAllText(view.FullName);

            //     //if (layout.Exists)
            //     //    content = File.ReadAllText(layout.FullName).Replace("@Body", content);

            //     viewCache[viewName] = content;

            // }

            // return Razor.Parse(content, model);

            var view = FindView(viewName);
            //var config = new TemplateServiceConfiguration
            //{
            //    EncodedStringFactory = new RawStringFactory(),
            //    Resolver = new DelegateTemplateResolver(name =>
            //    {
            //        var file = name;
            //        var content = File.ReadAllText(file);
            //        return content;
            //    })
            //};

            //string result;
            //using (var service = new TemplateService(config))
            //{
            //    result = service.Parse(view.FullName, model);
            //}

            //return result.ToString() ;
            var  content = File.ReadAllText(view.FullName);
            return Razor.Parse(content, model);

        }
     
    }
}
