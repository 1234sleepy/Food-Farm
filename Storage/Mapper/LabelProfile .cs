using AutoMapper;
using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;
using Storage.Entities;

namespace Storage.Mapper;

public class LabelProfile : Profile
{
    public LabelProfile()
    {
        CreateMap<Label, LabelModel>();
    }
}
