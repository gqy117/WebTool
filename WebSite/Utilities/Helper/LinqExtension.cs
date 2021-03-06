﻿namespace System.Linq
{
    using Expressions;

    public static class LinqExtension
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string ordering)
        {
            if (string.IsNullOrEmpty(ordering))
            {
                return source;
            }

            string[] sortArray = ordering.Split(' ');
            string sortCol = sortArray[0];
            string sortDir = sortArray[1];

            var type = typeof(T);
            var property = type.GetProperty(sortCol);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), sortDir, new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));
            
            return source.Provider.CreateQuery<T>(resultExp);
        }

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