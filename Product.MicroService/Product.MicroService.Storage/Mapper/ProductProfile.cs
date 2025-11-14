using AutoMapper;
using Product.MicroService.Domain.UseCases.LabelOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using Product.MicroService.Storage.Entities;

namespace Product.MicroService.Storage.Mapper;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductLabel, LabelModel>();
        CreateMap<ProductE, ProductModel>()
            .ForMember(dest => dest.Labels, s => s.MapFrom((x) => x.ProductLabel!.Select(l => new LabelModel { Name = l.Label!.Name, Id = l.Label.Id, Color = l.Label.Color })));
        //.ForMember(dest => dest.Labels, s => s.MapFrom((x, dest, dm, context) => x.ProductLabel!.Select(l => context.Mapper.Map<LabelModel>(l.Label)).ToList()));
    }
}
