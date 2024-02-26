using DevCircle.Todo.Application.Mapping.DTOs;
using MediatR;

namespace DevCircle.Todo.Application.Queries.Users
{
	public class GetUserRequest : IRequest<GetUserResponse>
	{
		public UserDTO? UserProxy { get; set; }
	}
}