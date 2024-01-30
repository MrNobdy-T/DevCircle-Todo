
using DevCircle_Todo.API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Diagnostics.Metrics;

namespace DevCircle_Todo.API
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Configuration.AddJsonFile("appsettings.json");

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var connectionString = builder.Configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

			var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);

			dataSourceBuilder.UseNodaTime();
			var dataSource = dataSourceBuilder.Build();

			builder.Services.AddDbContext<DatabaseContext>(options =>
			{
				options.UseNpgsql(dataSource, (x) => x.UseNodaTime());
			});

			var app = builder.Build();

			// If the database doesnt exist, migrate!
			using (var scope = app.Services.CreateScope())
			{
				var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
				await dbContext.Database.MigrateAsync();
			}

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}