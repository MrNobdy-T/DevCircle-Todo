using DevCircle.Todo.Application.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevCircle_Todo.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IMediator _mediator;

		public UserController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<GetUserResponse> Get([FromQuery] GetUserRequest request)
		{
			return await _mediator.Send(request);
		}
	}
}
