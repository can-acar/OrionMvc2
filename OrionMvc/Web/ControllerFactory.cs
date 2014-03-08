using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;

namespace OrionMvc.Web
{
    public class ControllerFactory : IControllerFactory
    {
        private static readonly object GeneralLock = new object();
        private static Type types = null;

        public IController CreateController(HttpContext context, RouteMeta meta)
        {
            var ControllerNmae = meta.Controller;


            if (meta.Controller == null)
            {
                return null;
            }
            var controllerType = GetController(ControllerNmae);


            var result = (IController)Activator.CreateInstance(controllerType);
            result.Context = context;
            result.Request = context.Request;

            return result;
        }
        public IController CreateController(HttpContextBase context, RouteMeta meta)
        {
            var ControllerNmae = meta.Controller;


            if (meta.Controller == null)
            {
                return null;
            }
            var controllerType = GetController(ControllerNmae);


            var result = (IController)Activator.CreateInstance(controllerType);
            //result.Context = context;
            //result.Request = context.Request;

            return result;
        }

        protected internal virtual Type GetController(string controller)
        {
            if (types == null)
            {
                lock (GeneralLock)
                {
                    if (types == null)
                    {
                        types = AppDomain.CurrentDomain.GetAssemblies()
                                  .SelectMany(a => a.GetTypes())
                                  .FirstOrDefault(t => t.Name == controller);
                    }
                }
            }
            return types;
        }
    }
}



