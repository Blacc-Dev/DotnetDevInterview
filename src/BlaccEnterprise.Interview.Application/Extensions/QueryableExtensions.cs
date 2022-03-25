using System;
using System.Linq;
using System.Linq.Expressions;

using BlaccEnterprise.Interview.Application.ViewModels.Base;
using BlaccEnterprise.Interview.Application.ViewModels.Base.Interfaces;

namespace BlaccEnterprise.Interview.Application.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int skipCount, int maxResultCount)
        {
            if (query == null)
                throw new ArgumentNullException("query");

            return query.Skip(skipCount).Take(maxResultCount);
        }

        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, IPagedResultViewModelBase pagedResult)
        {
            return query.PageBy(pagedResult.SkipCount, pagedResult.MaxResultCount);
        }

        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            return condition
                ? query.Where(predicate)
                : query;
        }

        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, int, bool>> predicate)
        {
            return condition
                ? query.Where(predicate)
                : query;
        }
    }
}