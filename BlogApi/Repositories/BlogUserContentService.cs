using BlogApi.Models;
using BlogApi.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repositories
{
    public class BlogUserContentService:IBlogUserContentInterface
    {
        private readonly BlogDbContext dbContext;
        public BlogUserContentService(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Delete(Guid Id)
        {
            await dbContext.BlogUserContent.Where(x => x.Id == Id).ExecuteDeleteAsync();
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BlogUserContent>> Get()
        {
            return await dbContext.BlogUserContent.ToListAsync();
        }

        public async Task<BlogUserContentDto> GetById(Guid Id)
        {
           
            var blogUserContent = await dbContext.BlogUserContent.FirstOrDefaultAsync(x => x.Id.Equals(Id));

            if (blogUserContent == null)
            {
                return null; 
            }

            return blogUserContent.AsDto();
        }


        public async Task<BlogUserContentDto> Post(CreateBlogUserContentDto createBlogUserContent)
        {
            var content = new BlogUserContent
            {
                Id = Guid.NewGuid(),
                Title = createBlogUserContent.Title,
                Content = createBlogUserContent.Content,
                blogUserId = createBlogUserContent.blogUserId,
                Created = DateTime.Now,
            };
            await dbContext.BlogUserContent.AddAsync(content);
            await dbContext.SaveChangesAsync();

            return content.AsDto();
        }

        public async Task<BlogUserContentDto> Put(Guid Id, UpdateBlogUserContentDto updateBlogUserContent)
        {
            var findid = dbContext.BlogUserContent.FirstOrDefault(x => x.Id.Equals(Id));
            findid.Title=updateBlogUserContent.Title;
            findid.Content=updateBlogUserContent.Content;

            await dbContext.SaveChangesAsync();

            return findid.AsDto();
        }
    }
}
