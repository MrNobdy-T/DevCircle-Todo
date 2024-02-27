using DevCircle.Todo.Application.Common.Interfaces;
using DevCircle.Todo.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Application.Extensions
{
	public static class Extensions
	{
		public static bool HasErrorOccured(this BaseResponse response)
		{
			return response.Exception is not null;
		}
	}
}
