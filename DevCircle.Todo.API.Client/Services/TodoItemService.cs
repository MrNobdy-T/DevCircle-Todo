using DevCircle.Todo.Application.Commands;
using DevCircle.Todo.Application.Common;
using DevCircle.Todo.Application.Queries.TodoItems;
using Flurl.Http;
using Microsoft.Extensions.Configuration;

namespace DevCircle.Todo.API.Client.Services
{
	public class TodoItemService : AbstractAPIClient
	{
		public TodoItemService(IConfiguration config) : base(config)
		{
			BaseURL.AppendPathSegment("TodoItem");
		}

		public async Task<CreateTodoItemResponse> Create(CreateTodoItemRequest request)
		{
			return await BaseURL.AppendPathSegment("Create").PostJsonAsync(request).ReceiveJson<CreateTodoItemResponse>();
		}

		public async Task<GetTodoItemResponse> GetAll()
		{
			return await BaseURL.AppendPathSegment("Get").GetJsonAsync<GetTodoItemResponse>();
		}

		public async Task<GetTodoItemResponse> Get(GetTodoItemRequest request)
		{
			return await BaseURL.AppendPathSegment("Get").SetQueryParam("request", request).GetJsonAsync<GetTodoItemResponse>();
		}
	}
}
