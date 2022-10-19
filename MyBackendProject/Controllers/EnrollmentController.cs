using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBackendProject.DAL;
using MyBackendProject.DTO;
using MyBackendProject.Models;

namespace MyBackendProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollment _enrollment;
        private readonly IMapper _mapper;

        public EnrollmentController(IEnrollment enrollmentDAL, IMapper mapper)
        {
            _enrollment = enrollmentDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<EnrollmentGetDTO> Get()
        {

            var results = _enrollment.GetAll();
            var DTO = _mapper.Map<IEnumerable<EnrollmentGetDTO>>(results);
            return DTO;
        }

        [HttpGet("{id}")]
        public EnrollmentGetDTO GetById(int id)
        {

            var result = _enrollment.GetById(id);
            if (result == null) throw new Exception($"data {id} tidak ditemukan");
            var DTO = _mapper.Map<EnrollmentGetDTO>(result);

            return DTO;
        }

        [HttpPost]
        public IActionResult Post(EnrollmentAddDTO enrollment)
        {
            try
            {
                var newElement = _mapper.Map<Enrollment>(enrollment);
                var result = _enrollment.Insert(newElement);
                var Dto = _mapper.Map<EnrollmentAddDTO>(result);

                return CreatedAtAction("Get", new { id = result.EnrollmentID }, Dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(EnrollmentEditDTO enrollmentDto)
        {
            try
            {
                var update = _mapper.Map<Enrollment>(enrollmentDto);
                var result = _enrollment.Update(update);
                var DTO = _mapper.Map<EnrollmentGetDTO>(result);
                return Ok(enrollmentDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _enrollment.Delete(id);
                return Ok($"Data dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
