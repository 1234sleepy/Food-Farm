using AutoMapper;
using Domain.UseCases.AdminProductOperation.Base;
using Storage.Entities;

namespace Storage.Mapper;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductModel>();
    }
}
