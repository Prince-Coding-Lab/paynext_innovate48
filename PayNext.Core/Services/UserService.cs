using AutoMapper;
using PayNext.Core.Dto;
using PayNext.Core.Entities;
using PayNext.Core.Enums;
using PayNext.Core.Interfaces;
using PayNext.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayNext.Core.Services
{
	public class UserService : IUserService
	{
		#region Fields
		private int status;
		private readonly IAsyncRepository<User> _userRepository;
		private readonly IMapper _mapper;
		#endregion

		#region Constructors 
		public UserService(IAsyncRepository<User> userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}
		#endregion
		public async Task<DatabaseResponse> RegisterAsync(UserCreateDto user)
		{
			var addUser = _mapper.Map<User>(user);
			var result = await _userRepository.AddAsync(addUser);
			if (result.Id != 0)
			{
				status = (int)DbReturnValue.CreateSuccess;
			}
			return new DatabaseResponse { ResponseCode = status };
		}

		public async Task<UserDto> LoginAsync(AuthenticateModel requestDto)
		{
			var filterSpecification = new UserFilterSpecification(requestDto.Username, requestDto.Password);
			var user = await _userRepository.GetByIdAsync(filterSpecification);
			var result = _mapper.Map<UserDto>(user);
			return result;

		}
	}
}