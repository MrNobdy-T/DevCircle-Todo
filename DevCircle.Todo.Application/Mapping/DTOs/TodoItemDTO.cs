using DevCircle.Todo.Domain.Entities;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Application.Mapping.DTOs
{
	public class TodoItemDTO
	{
		public int Id { get; set; }
		public UserDTO? Owner { get; set; }
		public LocalDateTime CreationDate { get; set; }
		public LocalDateTime? DueTime { get; set; }
		public string Title { get; set; } = string.Empty;
		public string? Description { get; set; }
	}
}
