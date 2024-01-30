using DevCircle.Todo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Database.Interfaces
{
	public interface IApplicationDbContext
	{
		DbSet<TodoItem> TodoItems { get; }

		DbSet<User> Users { get; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
