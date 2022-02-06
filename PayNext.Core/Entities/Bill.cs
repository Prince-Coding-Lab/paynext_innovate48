using PayNext.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayNext.Core.Entities
{
	public class Bill : BaseEntity, IAggregateRoot
	{
		public int CardId { get; set; }
		public Card Card { get; set; }
		public decimal? OutstandingBill { get; set; }
		public int? BillingCycleDay { get; set; }
		public DateTime? NextBillDate { get; set; }
		public int? CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public int? ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
