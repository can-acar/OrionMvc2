using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.Specialized;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using System.Collections;


namespace OrionMvc.Web
{
    public class ParamsCollection : Dictionary<string, ParamsCollection>
    {
        static ParamsCollection DEFAULT_VALUE = new ParamsCollection();
        static Regex KEY_REGEX = new Regex(@"^(?<name>.+?)\s*\[\s*(?<key>.*?)\s*\]", RegexOptions.Compiled);

        ProxyObject _value = null;

        public ParamsCollection()
        {
        }

        public ParamsCollection(object value)
        {
            _value = new ProxyObject(value);
        }

        new public ParamsCollection this[string key]
        {
            get
            {
                return this.ContainsKey(key) ? (ParamsCollection)base[key] : DEFAULT_VALUE;
            }
        }

        public ParamsCollection this[int index]
        {
            get
            {
                return index >= 0 && index < this.Count ? (ParamsCollection)this.Values.ElementAt(index) : DEFAULT_VALUE;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is ParamsCollection
                ? ((ParamsCollection)obj)._value == this._value
                : false
                ;
        }

        public override string ToString()
        {
            return (string)this;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        ///     Transparently converts <see cref="NameValueCollection"/> to
        ///     <see cref="ParamsCollection"/> and adds all values to the current collection.
        /// </summary>
        /// <returns>Returns source with items from source added to it.</returns>
        /// <param name="source">Target <see cref="ParamsCollection"/>.</param>
        /// <param name="collection">Source <see cref="NameValueCollection"/>.</param>
        static public ParamsCollection operator +(ParamsCollection target, NameValueCollection source)
        {
            ParamsCollection tmp = source;
            tmp.Each(p => target.Add(p.Key, p.Value));
            return target;
        }

        /// <summary>
        ///     Transparently converts <see cref="NameValueCollection"/> to 
        ///     <see cref="ParamsCollection"/>.
        /// </summary>
        /// <returns>Returns an instance of <see cref="ParamsCollection"/>.</returns>
        /// <param name="collection">Source <see cref="NameValueCollection"/>.</param>
        static public implicit operator ParamsCollection(NameValueCollection source)
        {
            ParamsCollection result = new ParamsCollection();

            for (int i = 0; i < source.Count; i++)
            {
                string key = source.Keys[i];
                string[] values = source.GetValues(key);
                Match m = KEY_REGEX.Match(key);

                // If key matches "name[value]", process it as nested list
                if (m.Success)
                {
                    NameValueCollection nested = new NameValueCollection();
                    string nestedName = m.Groups["name"].Value;
                    string nestedKey = m.Groups["key"].Value;

                    // If result already contains a key which we are trying to place nested list under,
                    // we will ignore it. This means that only the first value would be recorded for
                    // keys like "name[sub]" because they don't provide a nested array like "name[sub][]".
                    if (result.ContainsKey(nestedName))
                        continue;

                    // In order to be able to use NameValueToParams() on nested collections, we have to
                    // callect all items from the original collection which match "nestedKey[key][rest]".
                    // This allows for recursive calling of NameValueToParams().
                    Regex r = new Regex(string.Format(@"^{0}\s*\[\s*(?<key>.*?)\s*\]\s*(?<rest>.*?)\s*$", Regex.Escape(nestedName)));
                    int autoKey = 0;

                    foreach (string subKey in source)
                    {
                        m = r.Match(subKey);

                        if (m.Success)
                        {
                            nestedKey = m.Groups["key"].Value;
                            source.GetValues(subKey).Each(value => {
                                    nested.Add(
                                        //
                                        // Nested key contains current (auto)key and the rest of the original key to facilitate reccursion
                                        //    nested[.....][.....]
                                        //       ^     ^      ^ rest
                                        //       ^     ^ current
                                        //       ^ top level which we are iterating through
                                        //
                                        (nestedKey == "" ? autoKey++.ToString() : nestedKey) + m.Groups["rest"].Value,
                                        value
                                        );
                                }
                            );
                        }
                    }

                    result.Add(nestedName, (ParamsCollection)nested);
                } else
                {
                    result.Add(key, new ParamsCollection(values.First()));
                }
            }

            return result;
        }

        static public implicit operator string(ParamsCollection right)
        {
            return right._value != null ? right._value.AsString : null;
        }

        static public implicit operator int?(ParamsCollection right)
        {
            return right._value != null ? right._value.AsInt : null;
        }

        static public implicit operator double?(ParamsCollection right)
        {
            return right._value != null ? right._value.AsDouble : null;
        }

        static public implicit operator bool?(ParamsCollection right)
        {
            return right._value != null ? right._value.AsBool : null;
        }
    }
}
