using Domain.Models;
using Domain.UseCases.Base;

namespace Domain.Extensions;

public static class PaginationExtensions
{
    public static PaginationList<T> AsPagination<T>(this IQueryable<T> lst, PaginationQuery query)
    {
        return new PaginationList<T>
        {
            List = lst
            .Skip((query.Page - 1) * query.ItemPerPage)
            .Take(query.ItemPerPage).ToList(),
            TotalCount = lst.Count()
        };
    }
}
