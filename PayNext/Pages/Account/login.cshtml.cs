using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using PayNext.Core.Helpers.Common;
using PayNext.Core.Interfaces;
using PayNext.Core.Dto;
using PayNext.Core.Helpers.Common.Constant;

namespace PayNext.App.Pages.Account
{
	public class loginModel : PageModel
	{
		private readonly IUserService _userService;
		private readonly ISessionManager _sessionManager;

		#region PageProperties
		[ViewData]
		public string ErrorMessage { get; set; }

		[ViewData]
		public string SuccessMessage { get; set; }
		[BindProperty]
		public AuthenticateModel AuthenticateModel { get; set; }
		[BindProperty]
		public string RedirectURL { get; set; }
		[BindProperty]
		public bool RememberMe { get; set; }

		#endregion
		public loginModel(IUserService userService,
						ISessionManager sessionManager)
		{
			_userService = userService;
			_sessionManager = sessionManager;
		}
		public async Task<IActionResult> OnPostLoginAsync(string returnUrl = null)
		{
			if (ModelState.IsValid)
			{
				var response = await _userService.LoginAsync(AuthenticateModel);
				if (response != null)
				{
					if (response.Id != 0)
					{
						_sessionManager.SetSession(response);
						_sessionManager.SetObject("userInfo", response);

						var claims = new List<Claim>
														{
																new Claim(ClaimTypes.Name, response.FirstName + response.LastName),
																new Claim(ClaimTypes.Email,response.Email),
																new Claim(ClaimTypes.MobilePhone,response.PhoneNumber)
														};
						var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

						await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));


						if (RememberMe)
						{
							if (String.IsNullOrEmpty(_sessionManager.GetCookie("Paynext")))
							{
								_sessionManager.SetCookie("Paynext", AuthenticateModel.Username + ":" + AuthenticateModel.Password, 20);
							}
						}

						if (!string.IsNullOrEmpty(Request.Query["returnUrl"]) && Url.IsLocalUrl(Request.Query["returnUrl"]))
							return Redirect(returnUrl);
						else
						{
							return RedirectToPage("/Home");
						}
					}
					else
					{
						ErrorMessage = "Something went wrong. Please try again later.";
						return Page();
					}
				}
				else
				{
					ErrorMessage = "Username and/or password is incorrect";
					return Page();
				}
			}
			else
			{
				ErrorMessage = "Cannot process your request. Please try again.";
				return Page();
			}
		}
		public void OnGet()
		{
		}
	}
}
