using AutoMapper;
using MovieManagement.API.Services.DTO.Model;
using MovieManagement.Domain.Entities;

namespace MovieManagement.API.Profiles
{
    public class AutoMapperHandler : Profile
    {
        public AutoMapperHandler()
        {
            CreateMap<Actor, ActorName>()
                .ForMember(item => item.FirstName, opt => opt.MapFrom(item => item.FirstName))
                .ForMember(item => item.LastName, opt => opt.MapFrom(item => item.LastName)).ReverseMap();
        }
    }
}
