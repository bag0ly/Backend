using Books_n_Authors.Dtos;
using Books_n_Authors.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Security.AccessControl;

namespace Books_n_Authors.Repositories
{
    public class BookService : IBookInterface
    {
        private readonly BooksNAuthorsContext dbcontext;
        public async Task Delete(Guid Id)
        {
            using (var dbcontext = new BooksNAuthorsContext())
            {
                await dbcontext.Books.Where(x => x.Id == Id).ExecuteDeleteAsync();
                await dbcontext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Book>> Get()
        {
            IEnumerable<Book> res;
            using (var dbcontext = new BooksNAuthorsContext())
            {
                res = await dbcontext.Books.ToListAsync();
            }
            return res;
        }

        public async Task<Book> GetById(Guid Id)
        {
            using (var dbcontext = new BooksNAuthorsContext())
            {
                return await dbcontext.Books.SingleOrDefaultAsync(x => x.Id.Equals(Id));
            }
        }
        public async Task<IEnumerable<Book>> GetBooksByAuthor(Guid authorId)
        {
            using (var dbcontext = new BooksNAuthorsContext())
            {
                return await dbcontext.Books
                      .Where(book => book.Author == authorId)
                      .ToListAsync();
            }
        }

        public async Task<Book> Post(CreateBookDto createBookDto)
        {
            using (var dbContext = new BooksNAuthorsContext())
            {
                var author = await dbContext.Authors.FindAsync(createBookDto.Author);
                if (author == null)
                {
                    throw new InvalidOperationException("Author not found");
                }

                var book = new Book
                {
                    Id = Guid.NewGuid(),
                    Name = createBookDto.Name,
                    Genre = createBookDto.Genre,
                    Published = createBookDto.Published,
                    Author = author.Id,
                };

                await dbContext.Books.AddAsync(book);
                await dbContext.SaveChangesAsync();

                return book;
            }
        }


        public async Task<Book> Put(Guid Id, UpdateBookDto updateBookDto)
        {
            var findid = dbcontext.Books.FirstOrDefault(x => x.Id.Equals(Id));
            findid.Name=updateBookDto.Name;
            findid.Genre=updateBookDto.Genre;
            findid.Published = updateBookDto.Published;
            findid.Author = updateBookDto.Author;

            await dbcontext.SaveChangesAsync();

            return findid;
        }
    }
}
