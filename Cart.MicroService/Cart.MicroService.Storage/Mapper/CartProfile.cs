using AutoMapper;
using Cart.MicroService.Domain.UseCases.Base;
using Cart.MicroService.Storage.Entities;

namespace Cart.MicroService.Storage.Mapper;

internal class CartProfile : Profile
{
    public CartProfile()
    {
        CreateMap<CartEntity, CartModel>();
    }
}
