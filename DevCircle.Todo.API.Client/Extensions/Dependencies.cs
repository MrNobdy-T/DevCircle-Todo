using DevCircle.Todo.API.Client.Services;
using DevCircle.Todo.Application.Common;
using Flurl;
using Flurl.Http;
using Flurl.Http.Newtonsoft;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;
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
			// Reads the json of the executing assembly
			var config = new ConfigurationBuilder()
					.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
					.Build();

			Url baseUrl = config
				.GetSection("ClientSettings")
				.GetSection("API-URL").Value!
				.AppendPathSegment("api");


			FlurlHttp.Clients.WithDefaults(x =>
			{
				var settings = new JsonSerializerSettings();

				settings.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);

				x.Settings.JsonSerializer = new NewtonsoftJsonSerializer(settings);
			});

			services.AddScoped(x =>
			{
				return new TodoItemService(new Uri(baseUrl.ToString()));
			});

			services.AddScoped(x =>
			{
				return new UserService(new Uri(baseUrl.ToString()));
			});

			return services;
		}
	}
}
