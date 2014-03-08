using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace OrionMvc.Web
{
    public interface IHttpHeaders
    {
        NameValueCollection GetHeaders();
    }
}
