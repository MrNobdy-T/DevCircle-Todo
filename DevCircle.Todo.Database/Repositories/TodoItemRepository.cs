using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevCircle.Todo.Database.Interfaces;
using DevCircle.Todo.Domain.Entities;

namespace DevCircle.Todo.Database.Repositories
{
	public class TodoItemRepository : IRepository<TodoItem>
	{
		private readonly IApplicationDbContext _dbContext;

		public TodoItemRepository(IApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Add(TodoItem entity)
		{
			_dbContext.TodoItems.Add(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Delete(TodoItem entity)
		{
			_dbContext.TodoItems.Remove(entity);
			await _dbContext.SaveChangesAsync();
		}

		public Task<TodoItem> GetEntity(Func<TodoItem, bool> predicate)
		{
			throw new NotImplementedException();
		}
	}
}
