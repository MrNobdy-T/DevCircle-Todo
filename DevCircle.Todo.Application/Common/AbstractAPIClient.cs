using DevCircle.Todo.Application.Mapping;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Flurl.Http.Newtonsoft;
using Microsoft.Extensions.Configuration;
using Newtonsoft;
using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Application.Common
{
	public abstract class AbstractAPIClient
	{
		protected Url BaseURL { get; set; }

		public AbstractAPIClient(Url baseUrl)
		{
			BaseURL = baseUrl;
		}
	}
}
