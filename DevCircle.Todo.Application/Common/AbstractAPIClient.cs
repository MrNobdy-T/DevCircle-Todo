using Flurl;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Application.Common
{
	public abstract class AbstractAPIClient
	{
		protected Url BaseURL{ get; }

        public AbstractAPIClient(IConfiguration config)
        {
            BaseURL = config
                .GetSection("ClientSettings")
                .GetSection("API-URL").Value!
                .AppendPathSegment("api");
        }
    }
}
