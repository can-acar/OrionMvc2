using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace OrionMvc.Web
{
    public class Route : Dictionary<string, IRoute>, IRoute
    {
        /// <summary>
        /// Get/Sets the Defaults of the Route
        /// </summary>
        /// <value></value>
        public object Defaults { get;
            set; }

        /// <summary>
        /// Get/Sets the Path of the Route
        /// </summary>
        /// <value></value>
        public string Path { get;
            set; }

        /// <summary>
        /// Get/Sets the _Rule of the Route
        /// </summary>
        /// <value></value>
        public object Rule { get;
            set; }

        public string Controller { get;
            set; }

        public string Action { get;
            set; }

        /// <summary>
        /// Initializes a new instance of the <b>Route</b> class.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="defaults"></param>
        public Route(string path, object defaults)
        {
            Path = path;
            Defaults = defaults;
        }

        /// <summary>
        /// Initializes a new instance of the <b>Route</b> class.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="defaults"></param>
        /// <param name="rule"></param>
        public Route(string path, object defaults, object rule)
        {
            Path = path;
            Defaults = defaults;
            Rule = rule;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public string GetPath()
        {
            return Path;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public object GetDefault()
        {
            return Defaults;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public string GetFormat()
        {
            var Expression = Regex.Replace(Path, @"[.\\+*?[^\\]${}=!|]", @"\\\\$0");

            if (Convert.ToBoolean(Expression.LastIndexOf("(")) != false)
            {
                Expression = Expression.Replace("(", "(?:").Replace(")", ")?");
            }

            Expression = Regex.Replace(Expression, @":([\w]+)", new MatchEvaluator(this.Expression));

            Expression = "(^" + Expression + "$)";
            return Expression;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public string Expression(Match expression)
        {
            var parts = string.Empty;
            foreach (var rule in RulesParams(Rule))
            {
                if (rule.Key == expression.Groups[1].ToString())
                {
                    parts = string.Format(@"(?<{0}>{1})", expression.Groups[1], rule.Value);
                    return parts;
                }
            }
            return string.Format(@"(?<{0}>{1})", expression.Groups[1], @"([^\/]+)");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        private Dictionary<string, string> RulesParams(object values)
        {
            var param = new Dictionary<string, string>();
            if (values != null)
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(values))
                {
                    var val = descriptor.GetValue(values);
                    param[descriptor.Name] = val.ToString();
                }
            }
            return param;
        }
    }
}
