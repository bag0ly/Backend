using Books_n_Authors.Dtos;
using Books_n_Authors.Models;

namespace Books_n_Authors.Repositories
{
    public interface IAuthorInterface
    {
        Task<IEnumerable<Author>> Get();
        Task<Author> GetById(Guid Id);
        Task<IEnumerable<Author>> GetAuthorsByNationality(Guid Nationality);
        Task<Author> Post(CreateAuthorDto createAuthorDto);
        Task<Author> Put(Guid Id, UpdateAuthorDto updateAuthorDto);
        Task Delete(Guid Id);
    }
}
