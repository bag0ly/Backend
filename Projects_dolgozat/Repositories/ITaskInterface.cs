using Projects_dolgozat.Dtos;
using Projects_dolgozat.Models;

namespace Projects_dolgozat.Repositories
{
    public interface ITaskInterface
    {
        Task<IEnumerable<Tasks>> Get();
        Task<Tasks> GetById(Guid Id);
        Task<Tasks> Post(UserDto userTask, string taskDescription);
        Task<Tasks> Put(Guid Id, string taskDescription);
        Task Delete(Guid Id);
    }
}
