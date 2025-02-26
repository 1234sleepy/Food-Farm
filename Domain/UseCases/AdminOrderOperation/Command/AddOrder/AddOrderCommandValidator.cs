using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOrderOperation.Command.AddOrder
{
    public class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
    {
        public AddOrderCommandValidator()
        {
            RuleFor(x => x.name).MinimumLength(3)
                .WithErrorCode("Customer name is less than 3 letters");
            RuleFor(x => x.phone).GreaterThan(9).LessThan(12)
                .WithErrorCode("Phone is not correct");
            RuleFor(x => x.Items).NotNull()
                .WithErrorCode("Quantity can not be zero");
        }
    }
}
