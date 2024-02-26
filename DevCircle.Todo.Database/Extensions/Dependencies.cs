using DevCircle.Todo.Database.Interfaces;
using DevCircle.Todo.Database.Repositories;
using DevCircle.Todo.Domain.Entities;
using DevCircle_Todo.API.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Database.Extensions
{
	public static class Dependencies
	{
		public static IServiceCollection AddDatabaseServices(this IServiceCollection services)
		{
			services.AddTransient<IRepository<TodoItem>, TodoItemRepository>();
			services.AddTransient<IRepository<User>, UserRepository>();
			services.AddTransient<IApplicationDbContext, DatabaseContext>();

			return services;
		}
	}
}
