using AutoMapper;
using Product.MicroService.Domain.UseCases.LabelOperation.Base;
using Product.MicroService.Storage.Entities;

namespace Product.MicroService.Storage.Mapper;

public class LabelProfile : Profile
{
    public LabelProfile()
    {
        CreateMap<Label, LabelModel>()
            .ForMember(dest => dest.ProductId, s => s.MapFrom((x) => x.ProductLabels!.Select(pl => pl.ProductId).ToList()));
    }
}
