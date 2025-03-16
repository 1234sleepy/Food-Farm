using AutoMapper;
using Domain.UseCases.AdminOperatation.AdminOrderOperation.Base;
using Storage.Entities;

namespace Storage.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderModel>();
        }
    }
}
