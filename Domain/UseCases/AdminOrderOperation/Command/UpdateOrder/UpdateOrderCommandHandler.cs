using Domain.UseCases.AdminOrderOperation.Base;
using Domain.UseCases.AdminOrderOperation.Queries.GetOrder;
using Domain.UseCases.AdminProductOperation.Queries.GetAllProducts;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOrderOperation.Command.UpdateOrder
{
    public class UpdateOrderCommandHandler(IUpdateOrderStorage updateOrderStorage, IGetOrderStorage getOrderStorage, IValidator<UpdateOrderCommand> validator) : IRequestHandler<UpdateOrderCommand, OrderModel>
    {
        private readonly IUpdateOrderStorage _updateOrderStorage = updateOrderStorage;
        private readonly IGetOrderStorage _getOrderStorage = getOrderStorage;
        private readonly IValidator<UpdateOrderCommand> _validator = validator;
        public async Task<OrderModel> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);


            return await _updateOrderStorage.UpdateOrder(
                request.id,
                request.name,
                request.phone,
                request.createdAt,
                request.itemsId,
                cancellationToken);
        }
    }
    
}

