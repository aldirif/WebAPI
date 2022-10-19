using AutoMapper;
using MyBackendProject.DAL;
using MyBackendProject.DTO;
using MyBackendProject.Models;

namespace MyBackendProject.Profiles
{
    public class BackendProfiles : Profile
    {
        public BackendProfiles()
        {
            CreateMap<StudentAddDTO, Student>();
            CreateMap<Student, StudentAddDTO>();
            CreateMap<StudentGetDTO, Student>();
            CreateMap<Student, StudentGetDTO>();
            CreateMap<StudentEditDTO, Student>();
            CreateMap<Student, StudentEditDTO>();

            CreateMap<CourseGetDTO, Course>();
            CreateMap<Course, CourseGetDTO>();
            CreateMap<CourseAddDTO, Course>();
            CreateMap<Course, CourseAddDTO>();

            CreateMap<EnrollmentGetDTO, Enrollment>();
            CreateMap<Enrollment, EnrollmentGetDTO>();
            CreateMap<EnrollmentAddDTO, Enrollment>();
            CreateMap<Enrollment, EnrollmentAddDTO>();
            CreateMap<EnrollmentEditDTO, Enrollment>();
            CreateMap<Enrollment, EnrollmentEditDTO>();

            CreateMap<EnrollmentWithCourseDto, Enrollment>();
            CreateMap<Enrollment, EnrollmentWithCourseDto>();
            CreateMap<EnrollmentWithStudentDto, Enrollment>();
            CreateMap<Enrollment, EnrollmentWithStudentDto>();
            CreateMap<StudentWithCourseDTO, Enrollment>();
            CreateMap<Enrollment, StudentWithCourseDTO>();
            CreateMap<StudentWithCourseDTO, Student>();
            CreateMap<Student, StudentWithCourseDTO>();
            CreateMap<StudentWithCourseDTO, Course>();
            CreateMap<Course, StudentWithCourseDTO>();
        }
    }
}