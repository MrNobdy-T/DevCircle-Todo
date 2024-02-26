using DevCircle.Todo.Application.Mapping.DTOs;

namespace DevCircle.Todo.Application.Queries.Users
{
	public class GetUserResponse
	{
		public IEnumerable<UserDTO> UserDTOs { get; set; }
	}
}