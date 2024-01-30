using DevCircle.Todo.Application.Mapping.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Application.Queries.TodoItems
{
	public class GetTodoItemResponse
	{
		public IEnumerable<TodoItemDTO> TodoItemDTOs { get; set; } = null!; 
	}
}
