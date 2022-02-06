using PayNext.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayNext.Core.Entities
{
	public class CardTranscation : BaseEntity, IAggregateRoot
	{
		public int CardId { get; set; }
		public Card Card { get; set; }
		public int? MerchantID { get; set; }
		public decimal? Amount { get; set; }
		public int? CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public int? ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
