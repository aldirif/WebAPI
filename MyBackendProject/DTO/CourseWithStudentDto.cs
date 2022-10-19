namespace MyBackendProject.DTO
{
    public class CourseWithStudentDto
    {
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public List<EnrollmentWithCourseDto> Enrollments { get; set; }
    }
}
