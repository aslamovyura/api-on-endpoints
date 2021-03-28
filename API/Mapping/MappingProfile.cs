using API.PostEndpoints;
using ApplicationCore.Entities.PostAggregate;
using AutoMapper;

namespace API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostDto>();
        }
    }
}