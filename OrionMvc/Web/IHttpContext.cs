using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrionMvc.Web
{
    public interface IHttpContext
    {
        /// <summary>Gets or sets current context request.</summary>
        IHttpRequest Request
        {
            get;
            set;
        }

        /// <summary>Gets or sets current context response.</summary>
        //IHttpResponse Response
        //{
        //    get;
        //    set;
        //}

        /// <summary>Gets or sets application physical path.</summary>
        string PhysicalApplicationPath
        {
            get;
            set;
        }

        /// <summary>Gets or sets route which matched current request.</summary>
        IRoute Route
        {
            get;
            set;
        }

        /// <summary>Gets or sets virtual application path.</summary>
        string VirtualApplicationPath
        {
            get;
            set;
        }

        //ICookiesCollection Cookies
        //{
        //    get;
        //    set;
        //}

        ISession Session
        {
            get;
            set;
        }
    }
}
