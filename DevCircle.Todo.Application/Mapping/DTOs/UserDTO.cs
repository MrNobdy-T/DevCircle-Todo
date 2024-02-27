using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Application.Mapping.DTOs
{
	public class UserDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }

		public ICollection<TodoItemDTO> Todos { get; set; } = new List<TodoItemDTO>();
	}
}
