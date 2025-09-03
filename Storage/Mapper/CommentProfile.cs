using AutoMapper;
using Microsoft.Extensions.Configuration;
using Storage.Entities;

namespace Storage.Mapper;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<Comment,CommentModel>();
    }
}
