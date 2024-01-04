using Microsoft.EntityFrameworkCore;
using Projects_dolgozat.Dtos;
using Projects_dolgozat.Models;

namespace Projects_dolgozat.Repositories
{
    public class TaskService : ITaskInterface
    {
        private readonly ProjectDbContext dbContext;

        public TaskService(ProjectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Delete(Guid Id)
        {
            await dbContext.Tasks.Where(x => x.TaskID == Id).ExecuteDeleteAsync();
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tasks>> Get()
        {
            return await dbContext.Tasks.Include(t => t.Users).ToListAsync();
        }


        public async Task<Tasks> GetById(Guid Id)
        {
            var result = await dbContext.Tasks
                                        .Include(t => t.Users)
                                        .SingleOrDefaultAsync(x => x.TaskID.Equals(Id));
            return result;
        }


        public async Task<Tasks> Post(UserDto userTask, string taskDescription)
        {
            var existingTask = await dbContext.Tasks.FirstOrDefaultAsync(x => x.Users.UserID == userTask.UserID);

            if (existingTask != null)
            {
                return existingTask;
            }

            var newUser = await dbContext.Users.FirstOrDefaultAsync(u => u.UserID == userTask.UserID);

            if (newUser != null)
            {
                var newTask = new Tasks
                {
                    TaskID = Guid.NewGuid(),
                    TaskDescription = taskDescription,
                    Users = newUser
                };

                await dbContext.Tasks.AddAsync(newTask);
                await dbContext.SaveChangesAsync();

                return newTask;
            }
            else
            {
                return null; 
            }
        }


        public async Task<Tasks> Put(Guid Id, string taskDescription)
        {
            var task = await dbContext.Tasks
                                        .Include(t => t.Users)
                                        .FirstOrDefaultAsync(x => x.TaskID == Id);

            if (task != null)
            {
                task.TaskDescription = taskDescription;

                await dbContext.SaveChangesAsync();

                return task;
            }
            else
            {
                return null;
            }
        }

    }
}
