using BlogApi.Models;
using BlogApi.Models.Dtos;

namespace BlogApi.Repositories
{
    public interface IBlogUserContentInterface
    {
        Task<IEnumerable<BlogUserContent>> Get();
        Task<BlogUserContentDto> GetById(Guid Id);
        Task<BlogUserContentDto> Post(CreateBlogUserContentDto createBlogUserContent);
        Task<BlogUserContentDto> Put(Guid Id, UpdateBlogUserContentDto updateBlogUserContent);
        Task Delete(Guid Id);
    }
}
