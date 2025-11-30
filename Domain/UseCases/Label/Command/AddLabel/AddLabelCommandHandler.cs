using Domain.UseCases.Label.Base;
using FluentValidation;
using MediatR;

namespace Domain.UseCases.Label.Command.AddLabel;

public class AddLabelCommandHandler( IAddLabelStorage storage) : IRequestHandler<AddLabelCommand, LabelModel>
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
