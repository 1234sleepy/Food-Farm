using AutoMapper;
using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using Domain.UseCases.OrderStatusOperation.Base;
using Storage.Entities;

namespace Storage.Mapper
{
    public class OrderStatusProfile : Profile
    {
        public OrderStatusProfile()
        {
            CreateMap<OrderStatus, OrderStatusModel>();
        }
    }
}
