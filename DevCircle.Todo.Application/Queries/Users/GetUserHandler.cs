using DevCircle.Todo.Database.Interfaces;
using MediatR;
using DevCircle.Todo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DevCircle.Todo.Application.Mapping.DTOs;

namespace DevCircle.Todo.Application.Queries.Users
{
	public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
	{
		private readonly IRepository<User> _repository;
		private readonly IMapper _mapper;

		public GetUserHandler(IRepository<User> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
		{
			IEnumerable<UserDTO> users;
			if (request.UserProxy == null)
			{
				users = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(await _repository.GetAll());

				return new GetUserResponse()
				{
					UserDTOs = users
				};
			}

			users = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(await _repository.GetEntities(x => x.Name == request.UserProxy.Name
			&& x.Email == request.UserProxy.Email));
			return new GetUserResponse()
			{
				UserDTOs = users
			};
		}
	}
}
