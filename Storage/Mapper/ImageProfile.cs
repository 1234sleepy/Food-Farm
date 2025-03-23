using AutoMapper;
using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;
using Microsoft.Extensions.Configuration;
using Storage.Entities;

namespace Storage.Mapper;

public class ImageProfile : Profile
{
    public ImageProfile()
    {
        
    }
    public ImageProfile(IConfiguration configuration)
    {
        CreateMap<Image, ImageModel>().ForMember(dest => dest.ImageUrl, s => s.MapFrom(x => configuration["Host"]+x.Name));
    }
}
