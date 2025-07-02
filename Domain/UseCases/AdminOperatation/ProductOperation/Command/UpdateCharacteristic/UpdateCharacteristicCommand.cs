using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOperatation.ProductOperation.Command.UpdateCharacteristic;

public record class UpdateCharacteristicCommand(Guid Id, string Json) : IRequest
{

}
