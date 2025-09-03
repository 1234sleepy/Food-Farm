using AutoMapper;
using Domain.UseCases.Label.Base;
using Storage.Entities;

namespace Storage.Mapper;

public class ProductLabelProfile : Profile
{
    public ProductLabelProfile()
    {
        CreateMap<ProductLabel, ProductLabelModel>();
    }
}
