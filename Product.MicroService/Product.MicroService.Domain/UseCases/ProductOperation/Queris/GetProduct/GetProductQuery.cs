using MediatR;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProduct;

public record class GetProductQuery(Guid Id) : IRequest<ProductModel>
{
}
