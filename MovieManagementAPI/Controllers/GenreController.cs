using Microsoft.AspNetCore.Mvc;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Repository;
using Microsoft.AspNetCore.Http;
using MovieManagement.API.Services.DTO;
using MovieManagement.API.Services.DTO.Model;
using System.Collections.Generic;
using System.Linq;

namespace GenreManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "GetGenre")]
        public ActionResult GetGenre()
        {
            var genresFromRepo = _unitOfWork.Genre.GetAll();
            return Ok(genresFromRepo);
        }

        [HttpPost(Name = "SaveGenre")]
        public ActionResult SaveGenre([FromBody] Genre _genre)
        {
            _unitOfWork.Genre.Add(_genre);

            return Ok(true);
        }
    }
}
