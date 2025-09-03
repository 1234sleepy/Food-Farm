using Domain.UseCases.AdminOperatation.ProductOperation.Base;

namespace Domain.UseCases.Label.Query.GetAllLabels;

public interface IGetAllLabelsStorage
{
    Task<List<LabelModel>> GetAllLabels(CancellationToken cancellationToken);
}
