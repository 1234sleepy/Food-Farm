using Product.MicroService.Domain.UseCases.Label.Base;

namespace Product.MicroService.Domain.UseCases.Label.Query.GetAllLables
{
    public interface IGetAllLabelsStorage
    {
        Task<List<LabelModel>> GetAllLabels(CancellationToken cancellationToken);
    }
}
