namespace Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SessionHelper : ICacheHelper
    {
        public T GetCacheById<T>(string id, Func<T> func) where T : class
        {
            T obj = System.Web.HttpContext.Current.Session[id] as T;

            if (obj == null)
            {
                obj = func();
                System.Web.HttpContext.Current.Session.Add(id, obj);
            }

            return obj;
        }

        public IEnumerable<T> GetCacheTable<T>(string tableName, Func<IEnumerable<T>> func) where T : class
        {
            IEnumerable<T> obj = System.Web.HttpContext.Current.Session[tableName] as IEnumerable<T>;

            if (obj == null)
            {
                obj = func();
                System.Web.HttpContext.Current.Session.Add(tableName, obj);
            }

            return obj;
        }
    }
}
