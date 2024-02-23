using DevCircle.Todo.Application.Commands;
using DevCircle.Todo.Application.Common;
using DevCircle.Todo.Application.Queries.TodoItems;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;

namespace DevCircle.Todo.API.Client.Services
{
    public class TodoItemService : AbstractAPIClient
    {
        public TodoItemService(IConfiguration config) : base(config)
        {
        }

        public async Task<CreateTodoItemResponse> Create(CreateTodoItemRequest request)
        {
            return await BaseURL.AppendPathSegment("create").PostJsonAsync(request).ReceiveJson<CreateTodoItemResponse>();
        }

        public async Task<GetTodoItemResponse> GetAll()
        {
            return await BaseURL.AppendPathSegments("TodoItem").AppendPathSegment("Get").GetJsonAsync<GetTodoItemResponse>();
        }

        public async Task<GetTodoItemResponse> Get(GetTodoItemRequest request)
        {
            return await BaseURL.AppendPathSegment("TodoItem").AppendPathSegment("Get").GetJsonAsync<GetTodoItemResponse>();
        }
	}
}
