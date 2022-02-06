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
	public class CardService : ICardService
	{
		#region Fields
		private int status;
		private readonly IAsyncRepository<Card> _cardRepository;
		private readonly IMapper _mapper;
		#endregion

		#region Constructors 
		public CardService(IAsyncRepository<Card> cardRepository, IMapper mapper)
		{
			_cardRepository = cardRepository;
			_mapper = mapper;
		}
		#endregion
		#region Public Methods
		public async Task<DatabaseResponse> GetCardByNumberAsync(string cardNumber)
		{
			var filterSpecification = new CardFilterSpecification(cardNumber);
			var cardExists = await _cardRepository.ListAsync(filterSpecification);

			var result = _mapper.Map<IReadOnlyList<Card>, IReadOnlyList<CardDto>>(cardExists);
			if (result.Count > 0)
			{
				status = (int)DbReturnValue.RecordExists;
			}
			else
			{
				status = (int)DbReturnValue.NotExists;
			}
			return new DatabaseResponse { ResponseCode = status, Results = result };
		}
			#endregion
		}
}
