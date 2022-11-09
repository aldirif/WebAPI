using MyBackendProject.Models;

namespace MyBackendProject.DAL
{
    public interface IEnrollment
    {
        public IEnumerable<Enrollment> GetAll();
        public Enrollment GetById(int id);
        public Enrollment Insert(Enrollment enrollment);
        public void Delete(int id);
        Task<IEnumerable<Enrollment>> Pagging(int skip, int take);

    }
}
