using FluentValidation;
using MediatR;
using Product.MicroService.Domain.UseCases.LabelOperation.Base;

namespace Product.MicroService.Domain.UseCases.LabelOperation.Command.AddLabel;

public class AddLabelCommandHandler(IAddLabelStorage storage) : IRequestHandler<AddLabelCommand, LabelModel>
{
    private readonly IAddLabelStorage _storage = storage;
    public async Task<LabelModel> Handle(AddLabelCommand request, CancellationToken cancellationToken)
    {

        return await _storage.AddLabel(
            request.name,
            request.color,
            cancellationToken);
    }
}
