using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Label.Command.AddLabel;

public interface IAddLabelStorage
{
    Task<LabelModel> AddLabel(string name, string color, CancellationToken cancellationToken);
}
