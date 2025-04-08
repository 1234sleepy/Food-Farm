using AutoMapper;
using Domain.UseCases.AdminOperatation.OrderOperation.Base;
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
