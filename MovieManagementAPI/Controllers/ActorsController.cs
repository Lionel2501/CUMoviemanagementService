using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.API.DTO;
using MovieManagement.Domain.Repository;

namespace MovieManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "Get")]
        public ActionResult Get()
        {
            var actorsFromRepo = _unitOfWork.Actor.GetAll();
            return Ok(actorsFromRepo);
        }

        [HttpGet("movies")]
        public ActionResult GetWithMovies()
        {
            var actorsWithMovies = _unitOfWork.Actor.GetActorsWithMovies();
            return Ok(actorsWithMovies);
        }

        [HttpGet("biography")]
        public ActionResult GetWithBiographies()
        {
            var actorsWithBiographies = _unitOfWork.Actor.GetActorsWithBiographies();

            var actorDto = from actor in actorsWithBiographies
                           select new ActorResponse()
                           {
                               FirstName = actor.FirstName,
                               LastName = actor.LastName,
                               Movies = (!(actor.Movies is null)) ? 
                                    actor.Movies.Select(m => m.Name).ToList()
                                    : new List<string>()
                           };

            return Ok(actorDto);
        }
    }
}
