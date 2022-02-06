using PayNext.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayNext.Core.Interfaces
{
	public interface ICardService
	{
		Task<DatabaseResponse> GetCardByNumberAsync(string cardNumber);
	}
}
