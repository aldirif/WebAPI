using MyBackendProject.Models;

namespace MyBackendProject.DAL
{
    public interface ICourse
    {
        public IEnumerable<Course> GetAll();
        public Course GetById(int id);
        public IEnumerable<Course> GetByTitle(string title);
        public Course GetCourseWithStudent(int courseId);
        public Course Insert(Course course);
        public Course Update(Course course);
        public void Delete(int id);
        Task<IEnumerable<Course>> Pagging(int skip, int take);
    }
}
