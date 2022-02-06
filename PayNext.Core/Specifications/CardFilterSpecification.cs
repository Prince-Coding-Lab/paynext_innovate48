using PayNext.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayNext.Core.Specifications
{
	public class CardFilterSpecification : BaseSpecification<Card>
	{
		public CardFilterSpecification(string cardNumber)
			 : base(c => c.CardNumber == cardNumber)
		{
		}
	}
}
