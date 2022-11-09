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
    public class CourseController : ControllerBase
    {
        private readonly ICourse _course;
        private readonly IMapper _mapper;

        public CourseController(ICourse courseDAL, IMapper mapper)
        {
            _course = courseDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CourseGetDTO> Get()
        {

            var results = _course.GetAll();
            var DTO = _mapper.Map<IEnumerable<CourseGetDTO>>(results);

            return DTO;
        }

        [HttpGet("ByTitle")]
        public IEnumerable<CourseGetDTO> GetByName(string title)
        {
            List<CourseGetDTO> courseDtos = new List<CourseGetDTO>();
            var results = _course.GetByTitle(title);
            foreach (var result in results)
            {
                courseDtos.Add(new CourseGetDTO
                {
                    CourseID = result.CourseID,
                    Title = result.Title,
                    Credits = result.Credits
                });
            }
            return courseDtos;
        }

        [HttpGet("{id}")]
        public CourseGetDTO GetById(int id)
        {

            var result = _course.GetById(id);
            if (result == null) throw new Exception($"data {id} tidak ditemukan");
            var DTO = _mapper.Map<CourseGetDTO>(result);

            return DTO;
        }
        [HttpPost]

        public IActionResult Post(CourseAddDTO CreateDto)
        {
            try
            {
                var newcourse = _mapper.Map<Course>(CreateDto);
                var result = _course.Insert(newcourse);
                var Dto = _mapper.Map<CourseGetDTO>(result);
                return CreatedAtAction("Get", new { id = result.CourseID }, Dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(CourseGetDTO courseDto)
        {
            try
            {
                var update = _mapper.Map<Course>(courseDto);
                var result = _course.Update(update);
                var DTO = _mapper.Map<CourseGetDTO>(result);
                return Ok(courseDto);
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
                _course.Delete(id);
                return Ok($"Data dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Pagging/{skip}/{take}")]
        public async Task<IEnumerable<CourseGetDTO>> Pagging(int skip, int take)
        {

            var results = await _course.Pagging(skip, take);
            var DTO = _mapper.Map<IEnumerable<CourseGetDTO>>(results);

            return DTO;
        }
    }
}
