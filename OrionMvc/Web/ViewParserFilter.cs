using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace OrionMvc.Web
{
    public class ViewParserFilter : PageParserFilter
    {
        public override bool ProcessCodeConstruct(CodeConstructType codeType, string code)
        {
            if (codeType == CodeConstructType.ScriptTag)
            {
                throw new InvalidOperationException("Say NO to server script blocks!");
            }
            return base.ProcessCodeConstruct(codeType, code);
        }

        public override bool AllowCode
        {
            get
            {
                return true;
            }
        }

        public override bool AllowControl(Type controlType, ControlBuilder builder)
        {
            return (controlType == typeof(HtmlHead)
              || controlType == typeof(HtmlTitle)
              || controlType == typeof(ContentPlaceHolder)
              || controlType == typeof(Content)
              || controlType == typeof(HtmlLink));
        }

        public override bool AllowBaseType(Type baseType)
        {
            return true;
        }

        public override bool AllowServerSideInclude(string includeVirtualPath)
        {
            return true;
        }

        public override bool AllowVirtualReference(string referenceVirtualPath, VirtualReferenceType referenceType)
        {
            return true;
        }

        public override int NumberOfControlsAllowed
        {
            get
            {
                return -1;
            }
        }

        public override int NumberOfDirectDependenciesAllowed
        {
            get
            {
                return -1;
            }
        }
    }
}

