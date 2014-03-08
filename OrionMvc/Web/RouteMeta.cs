using System;
using System.Collections.Generic;
using System.Linq;

namespace OrionMvc.Web
{
    public class RouteMeta : Dictionary<string, object>, IRouteMeta
    {
        public IRoute Route { get;
            set; }

        public IRouter Router { get;
            set; }

        public string Controller
        {
            get
            {
                return (string)this["controller"];
            }
            set
            {
                this["controller"] = value;
            }
        }

        public string Action
        {
            get
            {
                return (string)this["action"];
            }
            set
            {
                this["action"] = value;
            }
        }

        public string Rule
        {
            get
            {
                return (string)this["rule"];
            }
            set
            {
                this["rule"] = value;
            }
        }
    }
}
