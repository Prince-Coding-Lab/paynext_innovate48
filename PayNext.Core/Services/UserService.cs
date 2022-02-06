using PayNext.Core.Dto;
using PayNext.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayNext.Core.Services
{
	public class UserService : IUserService
	{
		public Task<DatabaseResponse> RegisterAsync(UserCreateDto user)
		{
			throw new NotImplementedException();
		}
	}
}
