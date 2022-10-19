using Microsoft.EntityFrameworkCore;
using MyBackendProject.DAL;
using MyBackendProject.Models;

namespace MyBackendProject.DAL
{  
    public class CourseDAL : ICourse
    {
        private AppDbContext _dbcontext;
        public CourseDAL(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void Delete(int id)
        {
            var deleteCourse = GetById(id);
            if (deleteCourse == null)
                throw new Exception($"Data dengan id {id} tidak ditemukan");
            try
            {
                _dbcontext.Remove(deleteCourse);
                _dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Course> GetAll()
        {
            var results = _dbcontext.Courses.OrderBy(s => s.CourseID).ToList();
            return results;
        }

        public Course GetById(int id)
        {
            var result = _dbcontext.Courses.FirstOrDefault(s => s.CourseID == id);
            if (result == null)
                throw new Exception($"Data dengan id {id} tidak ditemukan");
            return result;
        }

        public IEnumerable<Course> GetByTitle(string title)
        {
            var results = _dbcontext.Courses.Where(s => s.Title.Contains(title)).ToList();
            return results;
        }

        public Course Insert(Course course)
        {
            try
            {
                _dbcontext.Courses.Add(course);
                _dbcontext.SaveChanges();
                return course;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Course Update(Course course)
        {
            try
            {
                var update = _dbcontext.Courses.FirstOrDefault(s => s.CourseID == course.CourseID);
                if (update == null)
                    throw new Exception($"Data dengan id {course.CourseID} tidak ditemukan");

                update.Title = course.Title;
                update.Credits = course.Credits;
                _dbcontext.SaveChanges();
                return course;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}