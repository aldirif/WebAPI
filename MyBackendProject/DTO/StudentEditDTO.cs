namespace MyBackendProject.DTO
{
    public class StudentEditDTO
    {
        public StudentGetDTO Student { get; set; }
        public CourseGetDTO Course { get; set; }
        public EnrollmentGetDTO Enrollment { get; set; }
    }
}
