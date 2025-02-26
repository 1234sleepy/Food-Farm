using AutoMapper;
using Domain.UseCases.AdminProductOperation.Base;
using Storage.Entities;

namespace Storage.Mapper;

public class ImageProfile : Profile
{
    public ImageProfile()
    {
        CreateMap<Image, ImageModel>();
    }
}
