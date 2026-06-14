using MediatR;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.UpdateCharacterisitc;

public record class UpdateCharacteristicCommand(string Json) : IRequest
{
    public Guid Id { get; set; }
}
