using DevCircle.Todo.API.Client.Services;
using DevCircle.Todo.Application.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.API.Client.Extensions
{
	public static class Dependencies
	{
		public static IServiceCollection AddAPIServices(this IServiceCollection services)
		{
			var config = new ConfigurationBuilder()
					.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
					.Build();

			services.AddTransient(x =>
			{
				return new TodoItemService(config);
			});


			return services;
		}
	}
}
