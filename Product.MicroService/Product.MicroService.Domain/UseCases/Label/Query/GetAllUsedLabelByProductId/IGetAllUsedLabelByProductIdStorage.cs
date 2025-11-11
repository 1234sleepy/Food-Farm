using Product.MicroService.Domain.UseCases.Label.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.Label.Query.GetAllUsedLabelByProductId
{
    public interface IGetAllUsedLabelByProductIdStorage
    {
        Task<List<LabelModel>> GetAllUsedLabels(Guid productId, CancellationToken cancellationToken);
    }
}
