using DevCircle.Todo.Database.Interfaces;
using DevCircle.Todo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevCircle_Todo.API.Database
{
	public class DatabaseContext : DbContext, IApplicationDbContext
	{
		public DbSet<User> Users { get; set; }

		public DbSet<TodoItem> TodoItems { get; set;}

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>();
			modelBuilder.Entity<TodoItem>();

			base.OnModelCreating(modelBuilder);
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			return base.SaveChangesAsync(cancellationToken);
		}
	}
}
