using AutoMapper;
using Domain.UseCases.AdminProductOperation.Base;
using Storage.Entities;

namespace Storage.Mapper;

public class LabelProfile : Profile
{
    public LabelProfile()
    {
        CreateMap<Label, LabelModel>();
    }
}
