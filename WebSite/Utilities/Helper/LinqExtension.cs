namespace System.Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Expressions;

    public static class LinqExtension
    {
        public static IQueryable<TSource> Search<TSource>(this IQueryable<TSource> source, string searchText, Expression<Func<TSource, bool>> predicate)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                return source;
            }
            else
            {
                return source.Where(predicate);
            }
        }
    }
}