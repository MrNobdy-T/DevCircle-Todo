using DevCircle.Todo.Application.Commands;
using DevCircle.Todo.Application.Queries.TodoItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NodaTime;

namespace DevCircle_Todo.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class TodoItemController : ControllerBase
	{
		private readonly IMediator _mediator;

		public TodoItemController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<CreateTodoItemResponse> Create([FromBody] CreateTodoItemRequest request)
		{
			return await _mediator.Send(request);
		}

		[HttpGet]
		public async Task<GetTodoItemResponse> Get([FromQuery] GetTodoItemRequest request)
		{
			return await _mediator.Send(request);
		}
	}
}
