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
        public static IQueryable<TSource> Search<TSource>(this IQueryable<TSource> source, string search, Expression<Func<TSource, bool>> predicate)
        {
            if (String.IsNullOrEmpty(search))
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