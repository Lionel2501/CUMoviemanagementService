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
    public class MoviesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "GetMovie")]
        public ActionResult GetMovie()
        {
            var moviesFromRepo = _unitOfWork.Movie.GetAll();
            return Ok(moviesFromRepo);
        }

        [HttpPost(Name = "SaveMovie")]
        public ActionResult SaveMovie([FromBody] IEnumerable<Movie> _movie)
        {
            try
            {
                _unitOfWork.Movie.AddRange(_movie);
                return Ok(true);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
