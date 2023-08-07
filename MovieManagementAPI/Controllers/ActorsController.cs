using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.API.Services.DTO;
using MovieManagement.API.Services.DTO.Model;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Repository;
using System.Collections.Generic;
using System.Linq;

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

            GetActorResponse actorResponse = new GetActorResponse();
            var result = actorResponse.ActorResponse(actorsWithMovies.ToList());

            /* var actorDto = from actor in actorsWithBiographies
                select new ActorResponse()
                {
                    FirstName = actor.FirstName,
                    LastName = actor.LastName,
                    Movies = (!(actor.Movies is null)) ? 
                        actor.Movies.Select(m => m.Name).ToList()
                        : new List<string>()
                };
            */

            return Ok(result);
        }

        [HttpPost(Name = "SaveActor")]
        public ActionResult SaveActor([FromBody] Actor _actor)
        {
            _unitOfWork.Actor.Add(_actor);

            return Ok(true);
        }
    }
}
