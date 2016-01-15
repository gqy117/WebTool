namespace Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface ICacheHelper
    {
        T GetCache<T>(string key, Func<T> func) where T : class;
    }
}
