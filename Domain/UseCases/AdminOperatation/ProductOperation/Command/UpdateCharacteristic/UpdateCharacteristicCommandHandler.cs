using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOperatation.ProductOperation.Command.UpdateCharacteristic;

public class UpdateCharacteristicCommandHandler(IUpdateCharacteristicStorage storage) : IRequestHandler<UpdateCharacteristicCommand>
{
    public Task Handle(UpdateCharacteristicCommand request, CancellationToken cancellationToken)
    {
        return storage.UpdateCharacteristic(request.Id, request.Json, cancellationToken);
    }
}
