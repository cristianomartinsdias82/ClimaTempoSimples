using ClimaTempoSimples.Application.Common;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace ClimaTempoSimples.Infrastructure.Persistence
{
    public static class LinqExtensions
    {
        public static async Task<IEnumerable<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, PaginationArgs paginationArgs, CancellationToken cancellationToken)
        {
            if (paginationArgs == null)
                throw new ArgumentNullException($"{paginationArgs} argument cannot be null");

            return await source
                        .Skip((1 - paginationArgs.PageNumber) * paginationArgs.PageSize)
                        .Take(paginationArgs.PageSize)
                        .ToListAsync(cancellationToken);
        }

        public static IEnumerable<T> ToPaginatedList<T>(this IQueryable<T> source, PaginationArgs paginationArgs)
        {
            if (paginationArgs == null)
                throw new ArgumentNullException($"{paginationArgs} argument cannot be null");

            return source
                   .Skip((1 - paginationArgs.PageNumber) * paginationArgs.PageSize)
                   .Take(paginationArgs.PageSize)
                   .ToList();
        }
    }
}
