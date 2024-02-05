using DevCircle.Todo.API.Client.Services;
using DevCircle.Todo.Application.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.API.Client.Extensions
{
	public static class Extension
	{
		public static IServiceCollection AddAPIServices(this IServiceCollection services)
		{
			var config = new ConfigurationBuilder()
					.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
					.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
					.Build();

			services.AddTransient<AbstractAPIClient, TodoItemService>(x =>
			{
				return new TodoItemService(config);
			});

			return services;
		}
	}
}
