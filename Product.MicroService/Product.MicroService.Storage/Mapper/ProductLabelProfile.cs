using AutoMapper;
using Product.MicroService.Domain.UseCases.LabelOperation.Base;
using Product.MicroService.Storage.Entities;

namespace Product.MicroService.Storage.Mapper;

public class ProductLabelProfile : Profile
{
    public ProductLabelProfile()
    {
        CreateMap<ProductLabel, ProductLabelModel>();
    }
}
