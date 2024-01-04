using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Projects_dolgozat.Dtos;
using Projects_dolgozat.Models;

namespace Projects_dolgozat.Repositories
{
    public class UserService:IUserInterface
    {
        private readonly ProjectDbContext dbContext;

        public UserService(ProjectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Delete(Guid id)
        {
            await dbContext.Users.Where(x => x.UserID == id).ExecuteDeleteAsync();
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Users>> Get()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<Users> GetById(Guid Id)
        {
            var result = dbContext.Users.SingleOrDefaultAsync(x => x.UserID.Equals(Id));
            return await result;
        }

        public async Task<Users> Post(CreateUserDto createUserDto)
        {
            var users = new Users
            {
               UserID = Guid.NewGuid(),
               UserName = createUserDto.UserName,
               Email = createUserDto.Email,
            };
            await dbContext.Users.AddAsync(users);
            await dbContext.SaveChangesAsync();

            return users;
        }

        public async Task<Users> Put(Guid Id, UpdateUserDto updateUserDto)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.UserID == Id);

            if (user != null)
            { 
                user.UserName = updateUserDto.UserName;
                user.Email = updateUserDto.Email;

              
                await dbContext.SaveChangesAsync();

                return user;
            }
            else
            {

                return null;
            }
        }

    }
}
