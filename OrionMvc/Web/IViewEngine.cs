
namespace OrionMvc.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;

    public interface IViewEngine
    {
        string Parse(string viewName);
        string Parse<T>(string viewName, T model);

    }

}
