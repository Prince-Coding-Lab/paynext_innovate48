using AutoMapper;
using PayNext.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayNext.Core.Dto
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Card, CardDto>();
			CreateMap<UserCreateDto, User>();
			CreateMap<User, UserDto>();
		}
	}
}
