using AutoMapper;
using Product.MicroService.Domain.Entities;
using Product.MicroService.Domain.UseCases.LabelOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Storage.Mapper;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductLabelEntity, LabelModel>();
        CreateMap<ProductEntity, ProductModel>()
            .ForMember(dest => dest.Labels, s => s.MapFrom((x) => x.ProductLabel!.Select(l => new LabelModel { Name = l.Label!.Name, Id = l.Label.Id, Color = l.Label.Color })));
      
    }
}
