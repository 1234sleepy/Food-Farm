using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOrderOperation.Command.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.name).MinimumLength(3)
                .WithErrorCode("Customer name is less than 3 letters");
            RuleFor(x => x.phone.Length).GreaterThan(9).LessThan(12)
                .WithErrorCode("Phone is not correct");
            RuleFor(x => x.itemsId).NotNull()
                .WithErrorCode("Quantity can not be zero");
        }
    }

}

