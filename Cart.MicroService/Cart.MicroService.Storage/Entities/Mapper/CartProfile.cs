using AutoMapper;
using Cart.MicroService.Domain.UseCases.Base;

namespace Cart.MicroService.Storage.Entities.Mapper;

internal class CartProfile : Profile
{
    public CartProfile()
    {
        CreateMap<CartEntity, CartModel>();
    }
}
