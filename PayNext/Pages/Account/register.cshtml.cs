using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PayNext.Core.Dto;
using PayNext.Core.Enums;
using PayNext.Core.Interfaces;

namespace PayNext.App.Pages.Account
{
	public class registerModel : PageModel
	{
    private readonly IUserService _userService;
    private readonly ICardService _cardService;
    #region PageProperties
    [ViewData]
    public string SuccessMessage { get; set; }
    [ViewData]
    public string ErrorMessage { get; set; }
    [BindProperty]
		public UserCreateDto UserCreateDto { get; set; }
    [BindProperty]
    public string ConfirmPassword { get; set; }
		#endregion
		public registerModel(IUserService userService, ICardService cardService)
		{
      _userService = userService;
      _cardService = cardService;

    }
		public async Task OnPostCreateUserAsync()
		{
      if (ModelState.IsValid)
      {
        if (UserCreateDto.Password == ConfirmPassword)
        {
          var cardDetail =await _cardService.GetCardByNumberAsync(UserCreateDto.CardNumber);
          UserCreateDto.CardId = cardDetail.Id;
          var response = await _userService.RegisterAsync(UserCreateDto);
          if (response.ResponseCode == (int)DbReturnValue.CreateSuccess)
          {
            SuccessMessage = "User Created Successfully !";
            UserCreateDto = null;
          }
          else
          {
            ErrorMessage = "Some Error Occured";
          }
        }
        else
        {
          ErrorMessage = "Passwords do not match.";
        }
      }
      else
      {
        var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
        ErrorMessage = "Cannot process your request. Please try again. " + message;
      }
    }
		public void OnGet()
		{
		}
	}
}
