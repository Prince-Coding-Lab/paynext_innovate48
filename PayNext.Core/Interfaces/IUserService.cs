using PayNext.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayNext.Core.Interfaces
{
	public interface IUserService
	{
		Task<UserDto> LoginAsync(AuthenticateModel requestDto);
		Task<DatabaseResponse> RegisterAsync(UserCreateDto user);
	}
}
