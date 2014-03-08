namespace OrionMvc.Web
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    public interface IView
    {
       string Render(HttpContext context, IController controller, string path);
       // void Render(HttpContext context, IController controller, string path);
        string GetPathView(IController controller, string path);
        object PartialRender(HttpContext context, IController controller, string path);

        dynamic RenderLayout(HttpContext httpContext, Controller controller, string ViewName);
    }
}
