using AutoMapper;
using Product.MicroService.Domain.Entities;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Command.AddProduct;
using Product.MicroService.Domain.UseCases.ProductOperation.Command.UpdateProduct;

namespace Product.MicroService.Domain.Mapper;

public class ProductEntityProfile : Profile
{
    public ProductEntityProfile()
    {
        CreateMap<UpdateProductCommand, ProductEntity>();
        CreateMap<ProductJsonModel, ProductEntity>();
        CreateMap<AddProductCommand, ProductEntity>()
            .ForMember(x => x.ProductLabel, x => x.MapFrom(s => s.Labels.Select(l => new ProductLabelEntity { LabelId = l.Id})));
    }
}
