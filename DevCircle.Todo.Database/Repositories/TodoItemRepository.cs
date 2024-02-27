using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using DevCircle.Todo.Database.Interfaces;
using DevCircle.Todo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
			_dbContext.Users.AttachRange(entity.Owner);
			await _dbContext.TodoItems.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<bool> Any(Expression<Func<TodoItem, bool>> predicate)
		{
			return await _dbContext.TodoItems.AnyAsync(predicate);
		}

		public async Task Delete(TodoItem entity)
		{
			_dbContext.TodoItems.Remove(entity);
			await _dbContext.SaveChangesAsync();
		}

		public Task<IEnumerable<TodoItem>> GetAll()
		{
			var todoItems = _dbContext.TodoItems.Include(x => x.Owner);
			return Task.FromResult<IEnumerable<TodoItem>>(todoItems);
		}

		public Task<IEnumerable<TodoItem>> GetEntities(Func<TodoItem, bool> predicate)
		{
			var entity = _dbContext.TodoItems.Where((x) => predicate(x));

			return Task.FromResult<IEnumerable<TodoItem>>(entity);
		}

		public async Task Update(TodoItem updatedItem)
		{
			var todoItem = _dbContext.TodoItems.FirstOrDefault(item => item.Id == updatedItem.Id);
			if(todoItem == null)
			{
				throw new ArgumentNullException(nameof(todoItem));
			}

			// Update properties
			if (!string.IsNullOrEmpty(updatedItem.Title))
			{
				todoItem.Title = updatedItem.Title;
			}

			if (updatedItem.Description != null)
			{
				todoItem.Description = updatedItem.Description;
			}

			if (updatedItem.DueTime != default)
			{
				todoItem.DueTime = updatedItem.DueTime;
			}

			todoItem.IsCompleted = updatedItem.IsCompleted;

			// Save changes to the database
			_dbContext.TodoItems.Update(todoItem);
			await _dbContext.SaveChangesAsync();
		}
	}
}
