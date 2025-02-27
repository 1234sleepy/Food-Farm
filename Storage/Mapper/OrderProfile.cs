using AutoMapper;
using Domain.UseCases.AdminOrderOperation.Base;
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
