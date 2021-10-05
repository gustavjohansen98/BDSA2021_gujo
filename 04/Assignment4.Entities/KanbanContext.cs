using Microsoft.EntityFrameworkCore;

namespace Assignment4.Entities
{
    public class KanbanContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        public KanbanContext(DbContextOptions<KanbanContext> options) : base(options)
        {
            // db password = b3b28432-360f-4676-9006-b6a7f7f1ea47
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // ...
        }
    }
}
