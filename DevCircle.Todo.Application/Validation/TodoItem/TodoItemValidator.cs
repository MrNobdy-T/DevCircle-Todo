using DevCircle.Todo.Application.Mapping.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Application.Validation.TodoItem
{
	public class TodoItemValidator : AbstractValidator<TodoItemDTO>
	{
        public TodoItemValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .WithMessage("A title must be set!");
        }
    }
}
