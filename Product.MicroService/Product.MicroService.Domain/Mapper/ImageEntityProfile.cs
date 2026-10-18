using AutoMapper;
using Product.MicroService.Domain.Entities;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.Mapper;

public class ImageEntityProfile : Profile
{
    public ImageEntityProfile()
    {
        CreateMap<ImageEntity, ImageModel>()
            .ForMember(x => x.ImageUrl, x => x.MapFrom(s => "Images/" + s.Name));
    }
}
