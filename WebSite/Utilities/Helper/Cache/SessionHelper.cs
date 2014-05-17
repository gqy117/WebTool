using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebToolService
{
    public class SessionHelper : ICacheHelper
    {
        public T GetCache<T>(string key, Func<T> func) where T : class
        {
            T obj = (System.Web.HttpContext.Current.Session[key]) as T;

            if (obj == null)
            {
                obj = func();
                System.Web.HttpContext.Current.Session.Add(key, obj);
            }
            return obj;
        }
    }
}
