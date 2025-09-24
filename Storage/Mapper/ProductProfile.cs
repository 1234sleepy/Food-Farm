using AutoMapper;
using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using Domain.UseCases.Label.Base;
using Microsoft.Extensions.DependencyInjection;
using Storage.Entities;

namespace Storage.Mapper;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductLabel, LabelModel>();
        CreateMap<Product, ProductModel>()
            .ForMember(dest => dest.Labels, s => s.MapFrom((x) => x.ProductLabel!.Select(l => new LabelModel { Name = l.Label.Name, Id = l.Label.Id, Color = l.Label.Color})));
            //.ForMember(dest => dest.Labels, s => s.MapFrom((x, dest, dm, context) => x.ProductLabel!.Select(l => context.Mapper.Map<LabelModel>(l.Label)).ToList()));
    }
}
