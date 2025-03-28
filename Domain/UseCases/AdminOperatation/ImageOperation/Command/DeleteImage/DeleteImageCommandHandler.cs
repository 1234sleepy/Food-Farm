using Domain.UseCases.AdminOperatation.ImageOperation.Queries.GetImage;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Domain.UseCases.AdminOperatation.ImageOperation.Command.DeleteImage;

public class DeleteImageCommandHandler(IDeleteImageStorage deleteImageStorage, IGetImageStorage getImageStorage, ILogger<DeleteImageCommandHandler> logger) : IRequestHandler<DeleteImageCommand>
{
    private readonly IDeleteImageStorage _deleteImageStorage = deleteImageStorage;
    private readonly IGetImageStorage _getImageStorage = getImageStorage;
    private readonly ILogger<DeleteImageCommandHandler> _logger = logger;
    public async Task Handle(DeleteImageCommand request, CancellationToken cancellationToken)
    {
        var image = await _getImageStorage.GetImage(request.imageId, cancellationToken);
        await _deleteImageStorage.DeleteImage(request.imageId, cancellationToken);

        if (File.Exists(image.ImageUrl))
            File.Delete(image.ImageUrl);
        else {
            _logger.LogError("Image File({ImageName}, {ImageUrl}) was not found", image.Name, image.ImageUrl);
        }
    }
}
