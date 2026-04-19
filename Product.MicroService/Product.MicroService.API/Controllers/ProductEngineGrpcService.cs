using FoodFarm.Product.MicroService.API.Grpc;
using Grpc.Core;
using MediatR;
using Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProductsById;

namespace Product.MicroService.API.Controllers;

public class ProductEngineGrpcService(IMediator mediator) : ProductEngine.ProductEngineBase
{
    private readonly IMediator _mediator = mediator;
    public override async Task<GetProductsResponse> GetProducts(GetProductsRequest request, ServerCallContext context)
    {
        var model = await _mediator.Send(new GetProductsByIdQuery(request.Ids.ToList()));

        GetProductsResponse response = new GetProductsResponse();

        response.List.AddRange(model.Select(x => new GetProductsResponse.Types.ProductModel
        {
            Id = x.Id.ToString(),
            Name = x.Name,
            Price = (double)x.Price,
            QuantityLimit = x.QuantityLimit,
            DiscountPrice = (double)x.DiscountPrice!,
        }));

        return response;
    }

}
