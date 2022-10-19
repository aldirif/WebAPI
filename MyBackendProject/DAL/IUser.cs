using MyBackendProject.DTO;

namespace MyBackendProject.DAL
{
    public interface IUser
    {
        Task Registration(AddUserDto user);
        IEnumerable<UserGetDto> GetAll();
        Task<UserGetDto> Authenticate(AddUserDto user);
    }
}
