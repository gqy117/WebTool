namespace Utilities
{
    using System;

    public static class StringHelper
    {
        public static bool Contains(this string source, string toCheck)
        {
            return source.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}