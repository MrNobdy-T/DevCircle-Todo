﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
			try
			{
				_dbContext.Users.AttachRange(entity.Owner);
				await _dbContext.TodoItems.AddAsync(entity);
				await _dbContext.SaveChangesAsync();
			}
			catch(Exception ex) 
			{

			}
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
			var todoItems = _dbContext.TodoItems;

			return Task.FromResult<IEnumerable<TodoItem>>(todoItems);
		}

		public Task<IEnumerable<TodoItem>> GetEntities(Func<TodoItem, bool> predicate)
		{
			var entity = _dbContext.TodoItems.Where((x) => predicate(x));

			return Task.FromResult<IEnumerable<TodoItem>>(entity);
		}

		public Task Update(TodoItem entity)
		{
			throw new NotImplementedException();
		}
	}
}
