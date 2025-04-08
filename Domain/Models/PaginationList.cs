namespace Domain.Models
{
    public class PaginationList<T>
    {
        public required List<T> List { get; set; }

        public int TotalCount { get; set; }
    }
}
