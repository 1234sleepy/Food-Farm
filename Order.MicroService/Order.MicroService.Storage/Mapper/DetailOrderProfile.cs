using AutoMapper;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;
using Storage.Entities;

namespace Order.MicroService.Storage.Mapper;

public class DetailOrderProfile : Profile
{
    public DetailOrderProfile()
    {
        CreateMap<DetailOrder, OrderModel>();
    }
}
