using AutoMapper;
using DevCircle.Todo.Application.Mapping.DTOs;
using DevCircle.Todo.Database.Interfaces;
using DevCircle.Todo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Application.Queries.TodoItems
{
	public class GetTodoItemHandler : IRequestHandler<GetTodoItemRequest, GetTodoItemResponse>
	{
		private readonly IRepository<TodoItem> _repo;
		private readonly IMapper _mapper;

		public GetTodoItemHandler(IRepository<TodoItem> repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}

		public async Task<GetTodoItemResponse> Handle(GetTodoItemRequest request, CancellationToken cancellationToken)
		{
			if (request.TodoItemProxy == null)
			{
				var allTodos = await _repo.GetAll();
				var todoDTOs = _mapper.Map<IEnumerable<TodoItemDTO>>(allTodos);
				return new GetTodoItemResponse()
				{
					TodoItemDTOs = todoDTOs
				};
			}

			var todoItem = await _repo.GetEntity(x => x.Id == request.TodoItemProxy.Id);
			var todoDTO = _mapper.Map<TodoItemDTO>(todoItem);
			return new GetTodoItemResponse()
			{
				TodoItemDTOs = new List<TodoItemDTO> { todoDTO }
			};
		}
	}
}
