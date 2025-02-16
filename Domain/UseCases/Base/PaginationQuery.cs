namespace Domain.UseCases.Base;

public record class PaginationQuery()
{

    public int Page { get; set; }
    public int ItemPerPage { get; set; }
}
