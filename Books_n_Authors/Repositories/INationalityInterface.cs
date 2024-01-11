using Books_n_Authors.Dtos;
using Books_n_Authors.Models;

namespace Books_n_Authors.Repositories
{
    public interface INationalityInterface
    {
        Task<IEnumerable<Nationality>> Get();
        Task<Nationality> GetById(Guid Id);
        Task<Nationality> Post(string Country);
        Task<Nationality> Put(Guid Id,string Country);
        Task Delete(Guid Id);
    }
}
