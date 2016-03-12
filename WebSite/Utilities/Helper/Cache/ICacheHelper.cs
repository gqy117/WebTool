namespace Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface ICacheHelper
    {
        T GetCacheById<T>(string id, Func<T> func) where T : class;

        IEnumerable<T> GetCacheTable<T>(string tableName, Func<IEnumerable<T>> func) where T : class;
    }
}
