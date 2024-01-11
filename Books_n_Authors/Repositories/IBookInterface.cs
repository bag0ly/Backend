using Books_n_Authors.Dtos;
using Books_n_Authors.Models;

namespace Books_n_Authors.Repositories
{
    public interface IBookInterface
    {
        Task<IEnumerable<Book>> Get();
        Task<Book> GetById(Guid Id);
        Task<Book> Post(CreateBookDto createBookDto);
        Task<Book> Put(Guid Id, UpdateBookDto updateBookDto);
        Task Delete(Guid Id);
    }
}
