using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.ImageOperation.Command;

public class AddImageCommandHandler(IAddImageStorage addImageStorage) : IRequestHandler<AddImageCommand, ImageModel>
{
    private readonly IAddImageStorage _addImageStorage = addImageStorage;
    public async Task<ImageModel> Handle(AddImageCommand request, CancellationToken cancellationToken)
    {
        string path = Directory.GetCurrentDirectory();
        string folderName = "Images";
        string fileName = request.fileName.Insert(request.fileName.LastIndexOf("."),
                                                         DateTimeOffset.UtcNow.ToString("dd.MM.yyyy_hh.mm.ss"));
        string filePath = Path.Combine(path, folderName, fileName);

        if (!Directory.Exists(Path.Combine(path, folderName)))
        {
            Directory.CreateDirectory(Path.Combine(path, folderName));
        }

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await request.Stream.CopyToAsync(stream);
        }

        return await _addImageStorage.AddImage(request.productId, fileName, cancellationToken);
    }
}

