using MovieManagement.API.Services.DTO.Model;
using MovieManagement.Domain.Entities;

namespace MovieManagement.API.Services.DTO
{
    public class GetActorResponse
    {
        public List<ActorResponse> ActorResponse(List<Actor> actorsWithMovies)
        {
            List<ActorResponse> result = new List<ActorResponse>();

            foreach (var item in actorsWithMovies)
            {
                var actorResponse = new ActorResponse
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName
                };

                if (item.Movies is not null)
                {
                    actorResponse.Movies = new List<string>();
                    foreach (var movies in item.Movies)
                    {
                        actorResponse.Movies.Add(movies.Name);
                    }
                }

                if (item.Biography is not null)
                {
                    actorResponse.Biography = item.Biography.Description;
                }

                result.Add(actorResponse);
            }
            return result;
        }
    }
}
