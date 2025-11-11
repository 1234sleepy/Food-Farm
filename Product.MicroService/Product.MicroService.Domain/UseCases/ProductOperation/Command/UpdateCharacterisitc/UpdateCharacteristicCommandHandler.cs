using MediatR;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.UpdateCharacterisitc;

public class UpdateCharacteristicCommandHandler(IUpdateCharacteristicStorage storage) : IRequestHandler<UpdateCharacteristicCommand>
{
    public Task Handle(UpdateCharacteristicCommand request, CancellationToken cancellationToken)
    {
        return storage.UpdateCharacteristic(request.Id, request.Json, cancellationToken);
    }
}
