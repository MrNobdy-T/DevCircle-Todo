using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Domain.Exceptions
{
	public class EntityExistsException : DomainException
	{
		public string EntityName {  get; set; }

        public EntityExistsException(string entityName)
        {
            EntityName = entityName;
        }
    }
}
