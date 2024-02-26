using AutoMapper;
using DevCircle.Todo.Application.Mapping.DTOs;
using DevCircle.Todo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Application.Mapping
{
	public class UserMapping : Profile
	{
        public UserMapping()
        {
            CreateMap<User, UserDTO>()
                .ReverseMap();

            CreateMap<UserDTO, User>()
                .ReverseMap();
        }
    }
}
