using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using MediatR;

namespace Domain.UseCases.Label.Query.GetAllLabels;

public record class GetAllLabelsQuery() : IRequest<List<LabelModel>>
{
}
