using AutoMapper;
using DevCircle.Todo.Database.Interfaces;
using DevCircle.Todo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Application.Commands.TodoItems.Update
{
	public class UpdateTodoItemHandler : IRequestHandler<UpdateTodoItemRequest, UpdateTodoItemResponse>
	{
		private readonly IRepository<TodoItem> _repository;
		private readonly IMapper _mapper;

		public UpdateTodoItemHandler(IRepository<TodoItem> repository, IMapper mapper)
        {
			_repository = repository;
			_mapper = mapper;
		}

        public async  Task<UpdateTodoItemResponse> Handle(UpdateTodoItemRequest request, CancellationToken cancellationToken)
		{
			var entity = _mapper.Map<TodoItem>(request.TodoItemProxy);
			await _repository.Update(entity);

			return new UpdateTodoItemResponse();
		}
	}
}
