using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Web.UI;

namespace OrionMvc.Web
{
    public class ViewData : DynamicObject, IDictionary, ICollection, IEnumerable
    {
        Dictionary<string, object> _viewBag;

        public Dictionary<string, object> ViewBag { set; get; }

        public ViewData()
        {
            _viewBag = new Dictionary<string, object>();
            ViewBag = _viewBag;
        }

        public void DynamicDictionary(Dictionary<string, object> dictionary)
        {
            this._viewBag = dictionary;
        }


        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _viewBag[binder.Name] = value;
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            if (_viewBag.Keys.Contains(binder.Name))
            {

                result = _viewBag[binder.Name];
                return true;
            }

            result = null;
            return false;
        }

        public override System.Collections.Generic.IEnumerable<string> GetDynamicMemberNames()
        {
            return Keys.Cast<string>().AsEnumerable();
        }

        public object this[string key]
        {
            get
            {
                try
                {
                    return _viewBag[key];
                }
                catch (KeyNotFoundException ex)
                {
                    object result = null;
                    GetMember(this, key, out result);
                    throw;
                }
            }
            set { _viewBag[key] = value; }
        }

        private bool GetMember(ViewData viewData, string key, out object result)
        {
            var miArray = this.GetType().GetMember(key, BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance);
            if (miArray != null && miArray.Length > 0)
            {
                var mi = miArray[0];
                if (mi.MemberType == MemberTypes.Property)
                {
                    result = ((PropertyInfo)mi).GetValue(this, null);
                    return true;
                }
            }

            result = null;
            return false;
        }
        protected bool SetMember(ViewData viewData, string name, object value)
        {


            var miArray = this.GetType().GetMember(name, BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.Instance);
            if (miArray != null && miArray.Length > 0)
            {
                var mi = miArray[0];
                if (mi.MemberType == MemberTypes.Property)
                {
                    ((PropertyInfo)mi).SetValue(this, value, null);
                    return true;
                }
            }
            return false;
        }

        void IDictionary.Add(object key, object value)
        {
            ((IDictionary)_viewBag).Add(key, value);
        }

        public void Clear()
        {
            _viewBag.Clear();
        }

        bool IDictionary.Contains(object key)
        {
            return ((IDictionary)_viewBag).Contains(key);
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            return _viewBag.GetEnumerator();
        }

        bool IDictionary.IsFixedSize
        {
            get { return ((IDictionary)_viewBag).IsFixedSize; }
        }

        bool IDictionary.IsReadOnly
        {
            get { return ((IDictionary)_viewBag).IsReadOnly; }
        }

        public ICollection Keys
        {
            get { return _viewBag.Keys; }
        }

        void IDictionary.Remove(object key)
        {
            ((IDictionary)_viewBag).Remove(key);
        }

        public ICollection Values
        {
            get { return _viewBag.Values; }
        }

        object IDictionary.this[object key]
        {
            get
            {
                return ((IDictionary)_viewBag)[key];
            }
            set
            {
                ((IDictionary)_viewBag)[key] = value;
            }
        }

        void ICollection.CopyTo(Array array, int index)
        {
            ((IDictionary)_viewBag).CopyTo(array, index);
        }

        public int Count
        {
            get { return _viewBag.Count; }
        }

        bool ICollection.IsSynchronized
        {
            get { return ((IDictionary)_viewBag).IsSynchronized; }
        }

        object ICollection.SyncRoot
        {
            get { return ((IDictionary)_viewBag).SyncRoot; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary)_viewBag).GetEnumerator();
        }


    }
}
