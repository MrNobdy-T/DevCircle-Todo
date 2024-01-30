using DevCircle.Todo.Application.Mapping.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Application.Queries.TodoItems
{
	public class GetTodoItemRequest : IRequest<GetTodoItemResponse>
	{
		public TodoItemDTO? TodoItemProxy { get; set; }
	}
}
