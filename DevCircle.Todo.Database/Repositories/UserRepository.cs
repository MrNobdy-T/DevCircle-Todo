using DevCircle.Todo.Database.Interfaces;
using DevCircle.Todo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Database.Repositories
{
	internal class UserRepository : IRepository<User>
	{
		public Task Add(User entity)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Any(Func<User, bool> predicate)
		{
			throw new NotImplementedException();
		}

		public Task Delete(User entity)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<User>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<User>> GetEntities(Func<User, bool> predicate)
		{
			throw new NotImplementedException();
		}

		public Task Update(User entity)
		{
			throw new NotImplementedException();
		}
	}
}
