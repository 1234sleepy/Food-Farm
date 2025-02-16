using AutoMapper;
using Domain.Models;
using Storage.Entities;

namespace Storage.Mapper;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductModel>();
    }
}
