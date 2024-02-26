using DevCircle.Todo.Application.Mapping.DTOs;
using MediatR;

namespace DevCircle.Todo.Application.Commands.Users
{
	public class CreateUserRequest : IRequest<CreateUserResponse>
	{
		public UserDTO UserDTO { get; set; } = null!;
	}
}