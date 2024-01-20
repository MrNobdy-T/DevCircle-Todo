using DevCircle_Todo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevCircle_Todo.API.Database
{
	public class DatabaseContext : DbContext
	{
		public DbSet<User> Users { get; private set; }

		public DbSet<TodoItem> TodoItems { get; private set;}

        public DatabaseContext()
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
