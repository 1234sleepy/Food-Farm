﻿using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.ImageOperation.Command.AddImage;

public record class AddImageCommand(Guid productId, string fileName, Stream Stream) : IRequest<ImageModel>
{
}
