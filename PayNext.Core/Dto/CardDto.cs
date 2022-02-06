using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayNext.Core.Dto
{
	public class CardDto
	{
		public int Id { get; set; }
		public string CardNumber { get; set; }
		public DateTime IssueDate { get; set; }
		public DateTime ValidDate { get; set; }
		public bool IsActive { get; set; }
		public bool IsActiveAtApp { get; set; }
		public int? CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public int? ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
