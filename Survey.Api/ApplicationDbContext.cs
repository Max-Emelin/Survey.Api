using Microsoft.EntityFrameworkCore;
using Survey.Api.Entities;

namespace Survey.Api
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Interview> Interview { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Result> Result { get; set; }
        public DbSet<ResultAnswer> ResultAnswer { get; set; }
        public DbSet<Entities.Survey> Survey { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}