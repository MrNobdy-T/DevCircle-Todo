using DevCircle.Todo.Database.Interfaces;
using DevCircle.Todo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using NodaTime;
using Npgsql.TypeMapping;
using System.Reflection;

namespace DevCircle_Todo.API.Database
{
	public class DatabaseContext : DbContext, IApplicationDbContext
	{
		public DbSet<User> Users { get; set; }

		public DbSet<TodoItem> TodoItems { get; set; }

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TodoItem>()
				.HasOne<User>(x => x.Owner)
				.WithMany(x => x.Todos)
				.IsRequired();

			base.OnModelCreating(modelBuilder);
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			return base.SaveChangesAsync(cancellationToken);
		}
	}

	public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
	{
		public DatabaseContext CreateDbContext(string[] args)
		{
			var path = Assembly.GetExecutingAssembly().Location;

			var config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.Build();

			var connectionString = config.GetConnectionString("DefaultConnection");
			var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);

			dataSourceBuilder.UseNodaTime();
			var dataSource = dataSourceBuilder.Build();

			var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
			optionsBuilder.UseNpgsql(dataSource, (x) => x.UseNodaTime());

			return new DatabaseContext(optionsBuilder.Options);
		}
	}
}
