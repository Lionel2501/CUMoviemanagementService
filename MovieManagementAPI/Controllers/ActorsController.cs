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

        [HttpGet("dto")]
        public ActionResult GetWithMovies()
        {
            var actorsWithMovies = _unitOfWork.Actor.GetActorsWithMovies();

            GetActorResponse actorResponse = new GetActorResponse();
            var result = actorResponse.ActorResponse(actorsWithMovies.ToList());

            return Ok(result);
        }

        
        [HttpGet("linq")]
        public ActionResult GetWithLinq()
        {
            var actorsResponse = _unitOfWork.Actor.GetActorsLinq();

            GetActorResponse actorResponseModel = new GetActorResponse();

            var result = actorResponseModel.ActorResponseLinq(actorsResponse);


            /*
            IQueryable<ActorResponse> result = from actor
                         in actorsResponse
                         where actor.Movies.Count() > 0
                         select new ActorResponse()
                         {
                             FirstName = actor.FirstName,
                             LastName = actor.LastName,
                             //Movies = actor.Movies.Select(m => m.Name).ToList()
                             Movies = (List<string>)(
                                        from m 
                                        in actor.Movies
                                        select m.Name)
                         };
            */

            return Ok(result);
        }

        [HttpPost(Name = "SaveActor")]
        public ActionResult SaveActor([FromBody] Actor _actor)
        {
            try
            {
                _unitOfWork.Actor.Add(_actor);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        [HttpDelete(Name = "DeleteActor/{id}")]
        public ActionResult DeleteActor([FromBody] Actor id)
        {
            try
            {
                _unitOfWork.Actor.Remove(id);
                return Ok(true);
            }
            catch (Exception)
            {
                return Ok(false);
            }

        }
        */
    }
}
