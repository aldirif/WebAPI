﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBackendProject.DAL;
using MyBackendProject.DTO;
using MyBackendProject.Models;

namespace MyBackendProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;
        private readonly IMapper _mapper;

        public StudentController(IStudent studentDAL, IMapper mapper)
        {
            _student = studentDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<StudentGetDTO> Get()
        {

            var results = _student.GetAll();
            var DTO = _mapper.Map<IEnumerable<StudentGetDTO>>(results);
            return DTO;
        }

        [HttpGet("{id}")]
        public StudentGetDTO GetById(int id)
        {

            var result = _student.GetById(id);
            if (result == null) throw new Exception($"Data {id} tidak ditemukan");
            var DTO = _mapper.Map<StudentGetDTO>(result);
            return DTO;
        }

        [HttpGet("ByName")]
        public IEnumerable<StudentGetDTO> GetByName(string fristMidName, string lastName)
        {
            List<StudentGetDTO> studentDtos = new List<StudentGetDTO>();
            var results = _student.GetByName(fristMidName, lastName);
            foreach (var result in results)
            {
                studentDtos.Add(new StudentGetDTO
                {
                    ID = result.ID,
                    FirstMidName = result.FirstMidName,
                    LastName = result.LastName
                });
            }
            return studentDtos;
        }

        [HttpGet("WithCourse")]
        public IEnumerable<StudentWithCourseDTO> GetAllStudentWitchCourse()
        {
            var results = _student.GetAllStudentWithCourse();
            var DTO = _mapper.Map<IEnumerable<StudentWithCourseDTO>>(results);
            return DTO;
        }
        [HttpPost]
        public IActionResult Post(StudentAddDTO studentCreateDto)
        {
            try
            {
                var newStudent = _mapper.Map<Student>(studentCreateDto);
                var result = _student.Insert(newStudent);
                var Dto = _mapper.Map<StudentGetDTO>(result);

                return CreatedAtAction("Get", new { id = result.ID }, Dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(StudentAddDTO studentDto)
        {
            try
            {
                var student = _mapper.Map<Student>(studentDto);
                var result = _student.Update(student);
                var DTO = _mapper.Map<StudentGetDTO>(result);
                return Ok(studentDto);
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
                _student.Delete(id);
                return Ok($"Data dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("WithCourseId")]
        public StudentWithCourseIdDTO GetStudentWithCourse(int id)
        {
            var student = _student.GetStudentWithCourse(id);
            var DTO = _mapper.Map<StudentWithCourseIdDTO>(student);
            return DTO;
        }
    }
}
