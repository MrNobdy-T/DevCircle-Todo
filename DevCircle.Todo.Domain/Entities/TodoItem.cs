using NodaTime;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DevCircle.Todo.Domain.Entities
{
    public class TodoItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual User Owner { get; set; }

        public LocalDateTime CreationDate { get; set; }

        public LocalDateTime DueTime { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
