using AutoMapper;
using DevCircle.Todo.Database.Interfaces;
using DevCircle.Todo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Application.Commands
{
	public class CreateTodoItemHandler : IRequestHandler<CreateTodoItemRequest, CreateTodoItemResponse>
	{
		private readonly IRepository<TodoItem> _repo;
		private readonly IMapper _mapper;

		public CreateTodoItemHandler(IRepository<TodoItem> repo, IMapper mapper)
        {
			_repo = repo;
			_mapper = mapper;
		}

        public async Task<CreateTodoItemResponse> Handle(CreateTodoItemRequest request, CancellationToken cancellationToken)
		{
			var entity = _mapper.Map<TodoItem>(request.TodoItemDTO);
			await _repo.Add(entity);

			return new CreateTodoItemResponse();
		}
	}
}
