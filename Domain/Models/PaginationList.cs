namespace Domain.Models
{
    public class PaginationList<T>
    {
        public required IQueryable<T> List { get; set; }

        public int TotalCount { get; set; }
    }
}
