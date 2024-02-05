using DevCircle.Todo.Application.Commands;
using DevCircle.Todo.Application.Common;
using Flurl;
using Flurl.Http;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DevCircle.Todo.API.Client.Services
{
	public class TodoItemService : AbstractAPIClient
	{
        public TodoItemService(IConfiguration config)
        {
			BaseURL = config["API_URI"]!;
        }

        public async Task<CreateTodoItemResponse> Create(CreateTodoItemRequest request)
		{
			var test2 = BaseURL.AppendPathSegment("create");
			var test =  await BaseURL.AppendPathSegment("create").PostJsonAsync(request).ReceiveJson<CreateTodoItemResponse>();
			return test;
		}
	}
}
