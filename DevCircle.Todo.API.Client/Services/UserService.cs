using DevCircle.Todo.Application.Commands.Users;
using DevCircle.Todo.Application.Common;
using DevCircle.Todo.Application.Queries.Users;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.API.Client.Services
{
	public class UserService : AbstractAPIClient
	{
		public UserService(Url baseUrl) : base(baseUrl)
		{
			this.BaseURL.AppendPathSegment("User");
		}

		public async Task<CreateUserResponse> Create(CreateUserRequest request)
		{
			await new Url(BaseURL).AppendPathSegment("Create").PostJsonAsync(request);
			return new CreateUserResponse();
		}

		public async Task<GetUserResponse> GetAll()
		{
			return await new Url(BaseURL).AppendPathSegment("Get").GetJsonAsync<GetUserResponse>();
		}
	}
}
