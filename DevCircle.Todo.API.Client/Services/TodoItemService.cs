using DevCircle.Todo.Application.Commands;
using DevCircle.Todo.Application.Commands.TodoItems.Update;
using DevCircle.Todo.Application.Common;
using DevCircle.Todo.Application.Queries.TodoItems;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using System.Text.Json;

namespace DevCircle.Todo.API.Client.Services
{
	public class TodoItemService : AbstractAPIClient
	{
		public TodoItemService(Url baseUrl) : base(baseUrl)
		{
			BaseURL.AppendPathSegment("TodoItem");
		}

		public async Task<CreateTodoItemResponse> Create(CreateTodoItemRequest request)
		{
			return await new Url(BaseURL).AppendPathSegment("Create").PostJsonAsync(request).ReceiveJson<CreateTodoItemResponse>();
		}


		public async Task<GetTodoItemResponse> GetAll()
		{
			return await new Url(BaseURL).AppendPathSegment("Get").GetJsonAsync<GetTodoItemResponse>();
		}

		public async Task<GetTodoItemResponse> Get(GetTodoItemRequest request)
		{
			return await new Url(BaseURL).AppendPathSegment("Get").SetQueryParam("request", request).GetJsonAsync<GetTodoItemResponse>();
		}

		public async Task<UpdateTodoItemResponse> Update(UpdateTodoItemRequest request)
		{
			return await new Url(BaseURL).AppendPathSegment("Update").PostJsonAsync(request).ReceiveJson<UpdateTodoItemResponse>();
		}
	}
}
