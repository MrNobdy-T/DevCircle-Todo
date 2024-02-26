using DevCircle.Todo.Application.Mapping.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Application.Validation.User
{
	public class UserValidator : AbstractValidator<UserDTO>
	{
        public UserValidator()
        {
        }
    }
}
