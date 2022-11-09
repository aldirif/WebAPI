using Microsoft.EntityFrameworkCore;
using MyBackendProject.DAL;
using MyBackendProject.Models;

namespace MyBackendProject.DAL
{  
    public class CourseEF : ICourse
    {
        private AppDbContext _dbcontext;
        public CourseEF(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void Delete(int id)
        {
            var deleteCourse = GetById(id);
            if (deleteCourse == null)
                throw new Exception($"Data course dengan id {id} tidak ditemukan");
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
            var results = _dbcontext.Courses.Where(s => s.Title.Contains(title)).OrderBy(s => s.Title);
            return results;
        }

        public Course GetCourseWithStudent(int courseId)
        {
            var results = _dbcontext.Courses.Include(s => s.Enrollments).ThenInclude(s => s.Student)
                .FirstOrDefault(s => s.CourseID == courseId);
            if(results == null)
                throw new Exception($"Course id {courseId} tidak ditemukan");
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

        public async Task<IEnumerable<Course>> Pagging(int skip, int take)
        {
            var results = await _dbcontext.Courses
               .Skip(skip).Take(take).ToArrayAsync();
            return results;
        }

        public Course Update(Course course)
        {
            var updateCourse = GetById(course.CourseID);
            if (updateCourse == null)
                throw new Exception($"Data dengan id {course.CourseID} tidak ditemukan");
            try
            {
                updateCourse.Title = course.Title;
                updateCourse.Credits = course.Credits;
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