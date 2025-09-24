using AutoMapper;
using Domain.UseCases.Label.Base;
using Storage.Entities;

namespace Storage.Mapper;

public class LabelProfile : Profile
{
    public LabelProfile()
    {
        CreateMap<Label, LabelModel>()
            .ForMember(dest => dest.ProductId, s => s.MapFrom((x) => x.ProductLabels!.Select(pl => pl.ProductId).ToList()));
    }
}
