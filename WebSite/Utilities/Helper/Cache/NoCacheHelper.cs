namespace Utilities
{
    using System;
    using System.Collections.Generic;

    public class NoCacheHelper : ICacheHelper
    {
        public T GetCacheById<T>(string id, Func<T> func) where T : class
        {
            var obj = func();

            return obj;
        }

        public IEnumerable<T> GetCacheTable<T>(string tableName, Func<IEnumerable<T>> func) where T : class
        {
            var obj = func();

            return obj;
        }
    }
}