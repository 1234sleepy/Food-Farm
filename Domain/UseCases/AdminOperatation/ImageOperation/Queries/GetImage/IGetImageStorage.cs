﻿using Domain.UseCases.AdminOperatation.ProductOperation.Base;

namespace Domain.UseCases.AdminOperatation.ImageOperation.Queries.GetImage;

public interface IGetImageStorage
{
    Task<ImageModel> GetImage(Guid productId, CancellationToken cancellationToken);

    Task<bool> IsImageExists(Guid imageId, CancellationToken cancellationToken);
}
