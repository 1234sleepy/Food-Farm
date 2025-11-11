using MediatR;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.UpdateCharacterisitc
{
    public record class UpdateCharacteristicCommand(Guid Id, string Json) : IRequest
    {
    }
}
