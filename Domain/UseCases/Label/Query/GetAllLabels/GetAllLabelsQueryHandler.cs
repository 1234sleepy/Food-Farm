using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using FluentValidation;
using MediatR;

namespace Domain.UseCases.Label.Query.GetAllLabels;

public class GetAllLabelsQueryHandler(IGetAllLabelsStorage storage) : IRequestHandler<GetAllLabelsQuery, List<LabelModel>>
{
    private readonly IGetAllLabelsStorage _storage = storage;

    public Task<List<LabelModel>> Handle(GetAllLabelsQuery request, CancellationToken cancellationToken)
    {
       return _storage.GetAllLabels(cancellationToken);
    }
}
