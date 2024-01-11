using Books_n_Authors.Dtos;
using Books_n_Authors.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Books_n_Authors.Repositories
{
    public class NationalityService : INationalityInterface
    {
        private readonly BooksNAuthorsContext dbcontext;
        public async Task Delete(Guid Id)
        {
            using (var dbcontext = new BooksNAuthorsContext())
            {
                await dbcontext.Nationalities.Where(x => x.Id == Id).ExecuteDeleteAsync();
                await dbcontext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Nationality>> Get()
        {
            IEnumerable<Nationality> res;
            using (var dbcontext = new BooksNAuthorsContext())
            {
                res = await dbcontext.Nationalities
                  
                    .ToListAsync();
            }
            return res;
        }


        public async Task<Nationality> GetById(Guid Id)
        {
            using (var dbcontext = new BooksNAuthorsContext())
            {
                return await dbcontext.Nationalities.SingleOrDefaultAsync(x => x.Id.Equals(Id));
            }
        }

        public async Task<Nationality> Post(string Country)
        {
            var nation = new Nationality
            {
                Id = Guid.NewGuid(),
                Country = Country,
            };

            using (var dbcontext = new BooksNAuthorsContext())
            {
                await dbcontext.Nationalities.AddAsync(nation);
                await dbcontext.SaveChangesAsync();
            }

            return nation;
        }


        public async Task<Nationality> Put(Guid Id,string Country)
        {
            using (var dbContext = new BooksNAuthorsContext())
            {
                var findid = dbcontext.Nationalities.FirstOrDefault(x => x.Id.Equals(Id));
                findid.Country=Country;

                await dbcontext.SaveChangesAsync();

                return findid;
            }
        }
    }
}
