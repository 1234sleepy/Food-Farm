using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOperatation.ProductOperation.Command.UpdateCharacteristic;

public interface IUpdateCharacteristicStorage
{
    Task UpdateCharacteristic(Guid id, string json, CancellationToken cancellationToken);
}
