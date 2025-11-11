using Product.MicroService.Domain.UseCases.Label.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.Label.Command.AddLabel
{
    public interface IAddLabelStorage
    {
        Task<LabelModel> AddLabel(string name, string color, CancellationToken cancellationToken);
    }
}
