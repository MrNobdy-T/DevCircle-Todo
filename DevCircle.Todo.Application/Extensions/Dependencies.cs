using DevCircle.Todo.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Application.Extensions
{
	public static class Dependencies
	{
		public static IServiceCollection RegisterRequestHandlers(
				 this IServiceCollection services)
		{
			services.AddMediatR((x) =>
			{
				x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
			});

			return services;
		}

		public static IServiceCollection RegisterMappingProfiles(
				 this IServiceCollection services)
		{
			services.AddAutoMapper((x) =>
			{
				x.AddProfile(typeof(TodoItemMappings));
			});

			return services;
		}
	}
}
