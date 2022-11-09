namespace MyBackendProject.DTO
{
    public class EnrollmentStudentCourseDTO
    {
        public int EnrollmentId { get; set; }
        public int CourseID { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }
        public CourseGetDTO Course { get; set; }

        public StudentGetDTO Student { get; set; }
    }
}
