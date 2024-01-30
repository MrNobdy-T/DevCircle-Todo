using DevCircle_Todo.API.Entities;
using Microsoft.EntityFrameworkCore;
using NodaTime.Text;

namespace DevCircle_Todo.API.Database
{
	public class DatabaseContext : DbContext
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
	}
}
