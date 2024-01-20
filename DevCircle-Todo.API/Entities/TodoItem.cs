using NodaTime;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DevCircle_Todo.API.Entities
{
	public class TodoItem
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public User Owner { get; }

		public LocalDateTime CreationDate { get; }

		public LocalDateTime DueTime { get; set; }

		public string Title { get; set; }

		public string? Description { get; set; }

		public TodoItem(User owner, LocalDateTime creationDate, LocalDateTime dueTime, string title, string? description)
		{
			Owner = owner;
			CreationDate = creationDate;
			DueTime = dueTime;
			Title = title;
			Description = description;
		}
	}
}
