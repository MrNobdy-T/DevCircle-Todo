using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Database.Interfaces
{
	public interface IRepository<T>
	{
		Task Add(T entity);

		Task Delete(T entity);

		Task<T> GetEntity(Func<T, bool> predicate);

		Task<IEnumerable<T>> GetAll();
	}
}
