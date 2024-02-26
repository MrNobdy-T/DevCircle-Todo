using DevCircle.Todo.Application.Commands.Users;
using DevCircle.Todo.Application.Common;
using DevCircle.Todo.Application.Queries.Users;
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
		public UserService(IConfiguration config) : base(config)
		{
			this.BaseURL.AppendPathSegment("User");
		}

		public async Task<CreateUserResponse> Create(CreateUserRequest request)
		{
			return await this.BaseURL.AppendPathSegment("Create").PostJsonAsync(request).ReceiveJson<CreateUserResponse>();
		}

		public async Task<GetUserResponse> GetAll()
		{
			return await this.BaseURL.AppendPathSegment("Get").GetJsonAsync<GetUserResponse>();
		}
	}
}
