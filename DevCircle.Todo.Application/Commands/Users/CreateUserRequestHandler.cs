using AutoMapper;
using DevCircle.Todo.Database.Interfaces;
using DevCircle.Todo.Domain.Entities;
using DevCircle.Todo.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Application.Commands.Users
{
	public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
	{
		private readonly IRepository<User> _repository;
		private readonly IMapper _mapper;

		public CreateUserRequestHandler(IRepository<User> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
		{
			var user = _mapper.Map<User>(request.UserDTO);
			if (user == null)
			{
				throw new NullReferenceException(nameof(user));
			}
			if (await _repository.Any(x => x.Name == user.Name && x.Email == user.Email))
			{
				return new CreateUserResponse()
				{
					 Exception = new EntityExistsException(nameof(user))
				};
			}

			await _repository.Add(user);

			return new CreateUserResponse();
		}
	}
}
