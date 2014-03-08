using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OrionMvc.Web
{
    public interface IRoute : IDictionary<string, IRoute>
    {
        object Defaults { set;
            get; }

        object Rule { set;
            get; }

        string Path { set;
            get; }

        string Expression(Match expression);

        string GetFormat();

        string GetPath();

        object GetDefault();
    }
}
