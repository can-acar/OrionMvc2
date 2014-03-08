using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.UI;

namespace OrionMvc.Web
{
    public class ViewControl:UserControl
    {
        private ViewData _dynamicViewData;
        
        public dynamic ViewBag
        {
           
            get
            {
                if (this._dynamicViewData == null)
                {
                    this._dynamicViewData = new ViewData();
                }
                return this._dynamicViewData;
            }
        }

    }
}
