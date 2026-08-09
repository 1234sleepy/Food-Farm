using FoodFarm.Product.MicroService.API.Grpc;
using MediatR;
using Microsoft.Extensions.Logging;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Base;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;
using Order.MicroService.Domain.UseCases.OrderOperation.Command.UpdateOrder;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Command.AddOrder;

public class AddOrderCommandHandler(IAddOrderStorage addOrderStorage, IUpdateOrderStorage updateOrderStorage, ProductEngine.ProductEngineClient client, ILogger<AddOrderCommandHandler> logger) : IRequestHandler<AddOrderCommand, OrderModel>
{
    private readonly IAddOrderStorage _addOrderStorage = addOrderStorage;
    private readonly IUpdateOrderStorage _updateOrderStorage = updateOrderStorage;
    private readonly ProductEngine.ProductEngineClient _client = client;
    private readonly ILogger<AddOrderCommandHandler> _logger = logger;

    public async Task<OrderModel> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        decimal totalPrice = 0;
        decimal totalDiscount = 0;
        List<OrderItemModel> orderItems = new List<OrderItemModel>();
        var getProductRequest = new GetProductsRequest();

        OrderModel order = new OrderModel()
        {
            Name = request.Name,
            Phone = request.Phone,
            Description = request.Description,
            Email = request.Email
        };

        order = await _addOrderStorage.AddOrder(
            order,
            cancellationToken);

        var ids = orderItems.Select(x => x.ProductId.ToString());

        getProductRequest.Ids.AddRange(ids);

        var getProductResponse = await _client.GetProductsAsync(getProductRequest);

        foreach (var item in request.Items)
        {
            var product = getProductResponse.List.FirstOrDefault(x => x.Id == item.ProductId.ToString());

            if (product == null)
            {
                _logger.LogWarning("Product with id = {Id} was not found for orederid = {OrderId}", item.ProductId, order.Id);
                continue;
            }

            OrderItemModel orderItemM = new OrderItemModel()
            {
                ProductId = item.ProductId
            };

            product.QuantitySold++;

            orderItemM.Quantity = item.Quantity > product.QuantityLimit ? product.QuantityLimit : item.Quantity;

            totalPrice += (decimal)(item.Quantity * product.Price);

            totalDiscount += (decimal)(item.Quantity * product.DiscountPrice);

            orderItems.Add(orderItemM);
        }
        order.Items = orderItems;
        order.TotalPrice = totalPrice;
        order.TotalDiscount = totalDiscount;

        return await _updateOrderStorage.UpdateOrder(order.Id, order.Items, order.TotalPrice, order.TotalDiscount, cancellationToken);

    }
}
