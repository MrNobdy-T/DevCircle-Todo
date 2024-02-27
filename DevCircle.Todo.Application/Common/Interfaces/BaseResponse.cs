using DevCircle.Todo.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Application.Common.Interfaces
{
	public abstract class BaseResponse
	{
		public object? Exception { get; set; } 
	}
}
