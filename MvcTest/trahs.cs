using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Reflection;

namespace OrionMvc.Web
{
    public class Router : Dictionary<string, object>, IRouter
    {
        public static Dictionary<string, IRoute> RouterData = new Dictionary<string, IRoute>();
        IDictionary<string, object> _toDefault = null;
        private static List<IRoute> _RouterCollection = new List<IRoute>();
        List<IRoute> _parts = null;
        /* public IRouteMeta Meta
        {
            get;

            set;
        }
        */
        IRoute Route
        {
            set;
            get;
        }



        public static List<IRoute> RouterCollection = null;
        /*  { 
              get { return _RouterCollection; } 
              set { _RouterCollection = value; } 
          }*/


        public void Dispatch(HttpContext context)
        {
            var App = Application.Instance;
            var Path = context.Request.Path;
            App.Router.Match(Path.TrimEnd('/'));
            var routeMeta = App.Router.Meta;
            string actionResult = null;
            var _context = routeMeta.Route;

            IController controller = App.ControllerFactory.CreateController(context, routeMeta);
            controller.Render(context, routeMeta);
            actionResult = controller.Execute(context, routeMeta);
            context.Response.Write(actionResult);
        }



        public static Route Connect(string path, object _default)
        {
            Route router = new Route(path, _default);
            AddPath(router);
            return router;
        }

        public static Route Connect(string path, object _default, object rule)
        {
            Route router = new Route(path, _default, rule);
            AddPath(router);
            return router;
        }

        private static void AddPath(Route router)
        {

            // RouterData[router.GetPath()] = router;

            RouterCollection.Add(router);
        }


        public void ToDefault(object values)
        {
            /* Meta = new RouteMeta
             {
                 Route = this._route
             };*/
            _toDefault = new Dictionary<string, object>();
            if (values != null)
            {

                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(values))
                {
                    object val = descriptor.GetValue(values);
                    _toDefault[descriptor.Name] = val.ToString();

                }
            }

        }


        public IRouteMeta Match(string url)
        {
            RouteMeta result = new RouteMeta
            {
                Router = this,
                Route = this.Route

            };

            foreach (var route in RouterCollection)
            {
                Regex expression = new Regex(route.GetFormat());

                Match match = expression.Match(url);

                if (!match.Success)
                    return null;



                foreach (var key in _toDefault.Keys)
                    result[key] = _toDefault[key];

                foreach (var part in _parts)
                {
                    //var group = match.Groups[part.Name];
                }

                /*if (expression.IsMatch(url))
                {
                   // Meta.Route =(IRoute) route;
                   // Meta.Rule =(string) route.Rule;

                    Meta = ToDefault(route.GetDefault());

                    var Matches = expression.Match(url);

                    if (Matches != null)
                    {
                        foreach (string key in expression.GetGroupNames())
                        {
                            int isInt;
                            if (Int32.TryParse(key, out isInt) == false)
                            {
                                if (Matches.Groups[key].ToString() != "")
                                {
                                    Meta[key] = Matches.Groups[key].ToString();
                                }
                            }
                        }

                    }

                    break;
                }*/
            }
            return result;

        }



        void IRouter.Match(string url)
        {
            throw new NotImplementedException();
        }

        public RouteMeta Meta
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}

/* foreach (KeyValuePair<string, IRoute> route in RouterData)
 {
     Regex expression = new Regex(route.Value.GetFormat());


     if (expression.IsMatch(url))
     {
         Meta = ToDefault(route.Value.GetDefault());
         //RouterTable = (Dictionary<string, string>)toDefault(route.Value.GetDefault());
         Meta.Route = route.Value;

         var Matches = expression.Match(url);

         if (Matches != null)
         {
             foreach (string key in expression.GetGroupNames())
             {
                 int isInt;
                 if (Int32.TryParse(key, out isInt) == false)
                 {
                     if (Matches.Groups[key].ToString() != "")
                     {
                         Meta[key] = Matches.Groups[key].ToString();
                     }
                 }
             }

         }
                   
         break;
     }
 }*/