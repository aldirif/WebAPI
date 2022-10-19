using MyBackendProject.Models;

namespace MyBackendProject.DAL
{
    public interface IStudent
    {
        public IEnumerable<Student> GetAll();
        public Student GetById(int id);
        public IEnumerable<Student> GetByName(string fristMidNamme, string lastName);
        public IEnumerable<Student> GetAllWithCourse();
        public Student GetStudentWithCourse(int studentId);
        public Student Insert(Student student);
        public Student Update(Student student);
        public void Delete(int id);
        public void AddStudentToCourse(int studentId, int courseId);
        public void RemoveCourseFromStudent(int studentId);
    }
}
