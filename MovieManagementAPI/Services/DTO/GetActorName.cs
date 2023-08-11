using MovieManagement.API.Services.DTO.Model;
using MovieManagement.Domain.Entities;
using AutoMapper;

namespace MovieManagement.API.Services.DTO
{
    public class GetActorName
    {
        private readonly IMapper _mapper;

        public GetActorName(IMapper mapper)
        {
            _mapper = mapper;            
        }

        public List<ActorName> GetWithAutoMapper(List<Actor> actorsResponse)
        {
            try
            {
                List<ActorName> result = new List<ActorName>();

                result = _mapper.Map<List<ActorName>>(actorsResponse);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
