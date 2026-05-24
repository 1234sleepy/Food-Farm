using AutoMapper;
using Microsoft.Extensions.Configuration;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using Product.MicroService.Storage.Entities;

namespace Product.MicroService.Storage.Mapper;

public class ImageProfile : Profile
{
    public ImageProfile()
    {
        
    }
    public ImageProfile(IConfiguration configuration)
    {
        CreateMap<Image, ImageModel>().ForMember(dest => dest.ImageUrl, s => s.MapFrom(x => configuration["ImageBaseURL"] + x.Name));
    }
}
