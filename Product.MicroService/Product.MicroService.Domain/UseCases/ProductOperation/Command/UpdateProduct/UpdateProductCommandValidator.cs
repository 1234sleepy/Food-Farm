using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.name).MinimumLength(3)
                .WithErrorCode("Name is less than 3 letters"); ;

            RuleFor(x => x.price).GreaterThan(0)
                .WithErrorCode("Price can not be zero");
        }
    }
}
