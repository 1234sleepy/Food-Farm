using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.UseCases.AdminOrderOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminOrderOperation.Queries.GetOrder
{
    public record class GetOrderQuery(Guid Id) : IRequest<OrderModel>;
}
