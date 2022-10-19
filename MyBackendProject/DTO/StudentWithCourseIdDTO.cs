namespace MyBackendProject.DTO
{
    public class StudentWithCourseIdDTO
    {
        public ICollection<EnrollmentCourseDTO> Enrollments { get; set; }
    }
}
