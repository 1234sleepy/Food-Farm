using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOperatation.OrderOperation.Command.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3)
                .WithErrorCode("Customer name is less than 3 letters");
            RuleFor(x => x.Phone.Length).GreaterThan(9).LessThan(13)
                .WithErrorCode("Phone is not correct");
        }
    }

}

