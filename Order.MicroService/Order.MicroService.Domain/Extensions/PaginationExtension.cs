using Order.MicroService.Domain.UseCases.Base;

namespace Order.MicroService.Domain.Extensions;

public static class PaginationExtension
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
