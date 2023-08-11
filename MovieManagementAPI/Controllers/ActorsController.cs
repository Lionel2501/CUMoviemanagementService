using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.API.Services.DTO;
using MovieManagement.API.Services.DTO.Model;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Repository;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace MovieManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActorsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet(Name = "Get")]
        public ActionResult Get()
        {
            var actorsFromRepo = _unitOfWork.Actor.GetAll();
            return Ok(actorsFromRepo);
        }

        [HttpGet("dto")]
        public ActionResult GetActorsDBRelation()
        {
            var actorsWithMovies = _unitOfWork.Actor.GetActorsDBRelation();

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

            return Ok(result);
        }

        [HttpGet("automapper")]
        public ActionResult GetWithAutoMapper()
        {
            List<Actor> actorsResponse = _unitOfWork.Actor.GetWithAutoMapper();

            GetActorName actorNameModel = new GetActorName(_mapper);

            List<ActorName> result = actorNameModel.GetWithAutoMapper(actorsResponse);

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
