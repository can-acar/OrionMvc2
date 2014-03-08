using System;

namespace OrionMvc.Web
{
    public interface IControllerFactory
    {
        IController CreateController(System.Web.HttpContext context, RouteMeta meta);

        IController CreateController(System.Web.HttpContextBase context, RouteMeta routeMeta);
    }
}
