using BlogApi.Models;
using BlogApi.Models.Dtos;

namespace BlogApi
{
    public static class Extensions
    {
        public static BlogUserDto AsDto(this BlogUser blogUser) 
        {
            return new(blogUser.Id, blogUser.Username, blogUser.UserEmail,
                blogUser.UserPassword, blogUser.CreatedTime);
        }
        public static BlogUserContentDto AsDto(this BlogUserContent blogUserContent)
        {
            return new(blogUserContent.Id, blogUserContent.Title, blogUserContent.Content,
                blogUserContent.blogUserId, blogUserContent.Created);
        }
    }
}
