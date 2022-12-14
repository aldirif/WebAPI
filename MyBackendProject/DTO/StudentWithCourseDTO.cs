namespace MyBackendProject.DTO
{
    public class StudentWithCourseDTO
    {
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public ICollection<EnrollmentWithCourseDto> Enrollments { get; set; }
    }
}
