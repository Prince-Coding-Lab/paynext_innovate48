using PayNext.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayNext.Core.Entities
{
	public class User : BaseEntity, IAggregateRoot
	{
		#region Properties
		[Required]
		[StringLength(100)]
		public string FirstName { get; set; }
		[Required]
		[StringLength(100)]
		public string LastName { get; set; }
		[Required]
		[StringLength(150)]
		public string Email { get; set; }
		[StringLength(20)]
		public string PhoneNumber { get; set; }
		[Required]
		[StringLength(50)]
		public string Password { get; set; }
		public int? CardId { get; set; }
		public Card Card { get; set; }
		public int? CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public int? ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		#endregion
	}
}
