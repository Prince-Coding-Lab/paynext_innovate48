using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayNext.Core.Dto
{
	public class UserDto
	{
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
