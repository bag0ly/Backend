using Books_n_Authors.Dtos;
using Books_n_Authors.Models;
using Microsoft.EntityFrameworkCore;

namespace Books_n_Authors.Repositories
{
    public class AuthorService : IAuthorInterface
    {
        private readonly BooksNAuthorsContext dbcontext;

        public AuthorService(BooksNAuthorsContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task Delete(Guid Id)
        {
            await dbcontext.Authors.Where(x => x.Id == Id).ExecuteDeleteAsync();
            await dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> Get()
        {
            return await dbcontext.Authors
                .Include(x=>x.Books)
                .ToListAsync();
        }

        public async Task<Author> GetById(Guid Id)
        {
            return await dbcontext.Authors.SingleOrDefaultAsync(x => x.Id.Equals(Id));
        }

        public async Task<Author> GetByNationality(Guid Nationality) 
        {

        }

        public async Task<Author> Post(CreateAuthorDto createAuthorDto)
        {
            var author = new Author
            {
                Id = Guid.NewGuid(),
                Name = createAuthorDto.Name,
                Gender = createAuthorDto.Gender,
                Birthdate = createAuthorDto.Birthdate,
                Nationality = createAuthorDto.Nationality,
            };
            await dbcontext.Authors.AddAsync(author);
            await dbcontext.SaveChangesAsync();

            return author;
        }

        public async Task<Author> Put(Guid Id, UpdateAuthorDto updateAuthorDto)
        {
            var findid = dbcontext.Authors.FirstOrDefault(x => x.Id.Equals(Id));
            findid.Name = updateAuthorDto.Name;
            findid.Gender = updateAuthorDto.Gender;
            findid.Birthdate = updateAuthorDto.Birthdate;
            findid.Nationality = updateAuthorDto.Nationality;

            await dbcontext.SaveChangesAsync();

            return findid;
        }

    }
}
