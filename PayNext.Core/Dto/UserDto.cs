using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayNext.Core.Dto
{
	public class UserDto
	{
		#region Properties
		public int Id { get; set; }
		public string Token { get; set; }
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
		public int? CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public int? ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		#endregion
	}
	public class UserCreateDto
	{
    [Required]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Enter a length between 3 to 20 for First Name")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use only characters for First Name")]
    public string FirstName { get; set; }
    [Required]
    [StringLength(15, MinimumLength = 3, ErrorMessage = "Enter a length between 3 to 15 for Last Name")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use only characters for Last Name")]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [Phone]
    public string PhoneNumber { get; set; }
    [Required]
    public string Password { get; set; }
    public string CardNumber { get; set; }
    public int? CardId { get; set; }
  }
}
