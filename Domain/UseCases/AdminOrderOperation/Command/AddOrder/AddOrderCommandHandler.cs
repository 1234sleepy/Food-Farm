using Domain.UseCases.AdminOrderOperation.Base;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOrderOperation.Command.AddOrder
{
    public class AddOrderCommandHandler (IAddOrderStorage orderStorage, IValidator<AddOrderCommand> validator): IRequestHandler<AddOrderCommand, OrderModel>
    {
        private readonly IValidator<AddOrderCommand> _validator = validator;
        private readonly IAddOrderStorage _orderStorage = orderStorage;
        public async Task<OrderModel> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            return await _orderStorage.AddOrder(
                request.id,
                request.name,
                request.phone,
                request.createdAt,
                request.Items,
                cancellationToken);
        }
    }
    
}

