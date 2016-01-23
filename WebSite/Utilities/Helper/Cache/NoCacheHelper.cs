namespace Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class NoCacheHelper : ICacheHelper
    {
        public T GetCache<T>(string key, Func<T> func) where T : class
        {
            var obj = func();

            return obj;
        }
    }
}