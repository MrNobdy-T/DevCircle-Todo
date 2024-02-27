using DevCircle.Todo.Database.Interfaces;
using DevCircle.Todo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Database.Repositories
{
	internal class UserRepository : IRepository<User>
	{
		private readonly IApplicationDbContext _dbContext;

		public UserRepository(IApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Add(User entity)
		{
			await _dbContext.Users.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<bool> Any(Expression<Func<User, bool>> predicate)
		{
			return await _dbContext.Users.AnyAsync(predicate);
		}

		public Task Delete(User entity)
		{
			_dbContext.Users.Remove(entity);
			return Task.CompletedTask;
		}

		public Task<IEnumerable<User>> GetAll()
		{
			return Task.FromResult<IEnumerable<User>>(_dbContext.Users);
		}

		public Task<IEnumerable<User>> GetEntities(Func<User, bool> predicate)
		{
			return Task.FromResult<IEnumerable<User>>(_dbContext.Users.Where(x => predicate(x)));
		}

		public Task Update(User entity)
		{
			throw new NotImplementedException();
		}
	}
}
