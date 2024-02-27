using DevCircle.Todo.Application.Common.Interfaces;
using DevCircle.Todo.Application.Mapping.DTOs;

namespace DevCircle.Todo.Application.Queries.Users
{
	public class GetUserResponse : BaseResponse
	{
		public IEnumerable<UserDTO> UserDTOs { get; set; }
	}
}