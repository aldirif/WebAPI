using Microsoft.EntityFrameworkCore;
using MyBackendProject.Models;

namespace MyBackendProject.DAL
{
    public class StudentDAL : IStudent
    {
        private AppDbContext _dbcontext;
        public StudentDAL(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void Delete(int id)
        {
            var deleteStudent = GetById(id);
            if (deleteStudent == null)
                throw new Exception($"Data dengan id {id} tidak ditemukan");
            try
            {
                _dbcontext.Remove(deleteStudent);
                _dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Student> GetAll()
        {
            var results = _dbcontext.Students.OrderBy(s => s.ID).ToList();
            return results;
        }

        public IEnumerable<Student> GetAllStudentWithCourse()
        {
            var results = _dbcontext.Students.Include(s => s.Enrollments).ThenInclude(s => s.Course).ToList();
            return results;
        }

        public Student GetById(int id)
        {
            var result = _dbcontext.Students.FirstOrDefault(s => s.ID == id);
            if (result == null)
                throw new Exception($"Data dengan id {id} tidak ditemukan");
            return result;
        }

        public IEnumerable<Student> GetByName(string fristMidNamme, string lastName)
        {
            var results = _dbcontext.Students.Where(s => s.FirstMidName.Contains(fristMidNamme)).Where(s => s.LastName.Contains(lastName)).ToList();
            return results;
        }

        public Student GetStudentWithCourse(int id)
        {
            var result = _dbcontext.Students.Include(s => s.Enrollments)
             .FirstOrDefault(s => s.ID == id);
            if (result == null)
                throw new Exception($"Student id{id} tidak ditemukan");
            return result;
        }

        public Student Insert(Student student)
        {
            try
            {
                _dbcontext.Students.Add(student);
                _dbcontext.SaveChanges();
                return student;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Student Update(Student student)
        {
            try
            {
                var update = _dbcontext.Students.FirstOrDefault(s => s.ID == student.ID);
                if (update == null)
                    throw new Exception($"Data dengan id {student.ID} tidak ditemukan");

                update.LastName = student.LastName;
                update.FirstMidName = student.FirstMidName;
                _dbcontext.SaveChanges();
                return student;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
