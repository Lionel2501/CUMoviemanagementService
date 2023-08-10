using Microsoft.AspNetCore.Mvc;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Repository;

namespace MovieManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BiographyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BiographyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "GetBiography")]
        public ActionResult GetBiography()
        {
            var biographyFromRepo = _unitOfWork.Biography.GetAll();
            return Ok(biographyFromRepo);
        }

        [HttpPost(Name = "SaveBiography")]
        public ActionResult SaveBiography([FromBody] Biography _biography)
        {
            _unitOfWork.Biography.Add(_biography);

            return Ok(true);
        }

        [HttpPost("UpdateBiography")]
        public ActionResult UpdateBiography([FromBody] Biography _biography)
        {
            try
            {
                _unitOfWork.Biography.UpdateBiography(_biography);

                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
