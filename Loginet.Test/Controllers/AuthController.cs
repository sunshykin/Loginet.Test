using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Loginet.Test.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Loginet.Test.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IUserService userService;

		public AuthController(IUserService userService)
		{
			this.userService = userService;
		}

		// This method shouldn't be using at a real project. Stayed here just
		// for easy test Auth work with browser
		[HttpGet("")]
		public async Task<IActionResult> AuthWithGet([FromQuery]string email)
		{
			await InnerAuth(email);

			return Ok();
		}

		// This method should be used insted. With body or form
		[HttpPost("")]
		public async Task<IActionResult> AuthWithPost([FromBody]string email)
		{
			await InnerAuth(email);

			return Ok();
		}

		// Mocking some Auth work without actually checking credentials
		private async Task InnerAuth(string email)
		{
			var user = await userService.GetUserDataByEmail(email);
			if (user == null)
				return;

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Email, user.Email),
			};
			var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

			await HttpContext.SignInAsync(
				CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(claimsIdentity),
				new AuthenticationProperties
				{
					ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
				}
			);
		}
	}
}
