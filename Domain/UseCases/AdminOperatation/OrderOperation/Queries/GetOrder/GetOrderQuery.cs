using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.UseCases.AdminOperatation.OrderOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.OrderOperation.Queries.GetOrder
{
    public record class GetOrderQuery(Guid Id) : IRequest<OrderModel>;
}
