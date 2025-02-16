using Domain.UseCases.Base;

namespace Domain.Models.Bases;

public record class ContactQuery(string? Sort) : PaginationQuery;
