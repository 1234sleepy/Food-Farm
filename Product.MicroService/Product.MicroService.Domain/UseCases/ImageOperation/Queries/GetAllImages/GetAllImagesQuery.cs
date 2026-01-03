using MediatR;
using Product.MicroService.Domain.UseCases.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ImageOperation.Queries.GetAllImages;

public record class GetAllImagesQuery(string? Sort) : PaginationQuery, IRequest<PaginationList<ImageModel>>
{
}
