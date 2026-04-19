using FluentValidation;
using MediatR;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Base;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Command.AddOrder;

public class AddOrderCommandHandler(IAddOrderStorage orderStorage) : IRequestHandler<AddOrderCommand, OrderModel>
{
    private readonly IAddOrderStorage _orderStorage = orderStorage;
    public async Task<OrderModel> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        decimal totalPrice = 0;
        decimal totalDiscount = 0;
        List<OrderItemModel> orderItems = new List<OrderItemModel>();

        foreach (var item in request.Items)
        {

            Product product = await _dataContext.Products
                .AsNoTracking()
                .FirstAsync(p => p.Id == item.ProductId, cancellationToken);

            OrderItemModel orderItemM = new OrderItemModel()
            {
                ProductId = item.ProductId
            };

            product.QuantitySold++;

            orderItemM.Quantity = item.Quantity > product.QuantityLimit ? product.QuantityLimit : item.Quantity;

            totalPrice += item.Quantity * product.Price;

            totalDiscount += item.Quantity * product.DiscountPrice ?? 0;

            orderItems.Add(orderItemM);
        }

        OrderModel orderItem = new OrderModel()
        {
            Name = request.Name,
            Phone = request.Phone,
            Description = request.Description,
            Items = orderItems,
            TotalPrice = totalPrice,
            TotalDiscount = totalDiscount,
            Email = request.Email
        };

        return await _orderStorage.AddOrder(
            orderItem,
            cancellationToken);
    }
}