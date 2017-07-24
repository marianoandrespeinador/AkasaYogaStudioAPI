using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Akasa.Model.Core;

namespace Akasa.Services.Core
{
    public static class Extensions
    {
        public static IQueryable<T> WhereIsValid<T>(this IQueryable<T> thisQuery)
            where T : FiniteDataEntity
            => thisQuery?.Where(e => e.EndDate == null || e.EndDate > DateTime.Now);

        public static IEnumerable<T> WhereIsValid<T>(this IEnumerable<T> thisList)
            where T : FiniteDataEntity
            => thisList?.Where(e => e.EndDate == null || e.EndDate > DateTime.Now);
    }
}
