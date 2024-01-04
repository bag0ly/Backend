using Projects_dolgozat.Dtos;
using Projects_dolgozat.Models;

namespace Projects_dolgozat.Repositories
{
    public interface IUserInterface
    {
        Task<IEnumerable<Users>> Get();
        Task<Users> GetById(Guid Id);
        Task<Users> Post(CreateUserDto createUserDto);
        Task<Users> Put(Guid Id,UpdateUserDto updateUserDto);
        Task Delete(Guid id);
    }
}
