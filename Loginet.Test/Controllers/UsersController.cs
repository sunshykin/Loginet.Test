using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Loginet.Test.Dto;
using Loginet.Test.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Loginet.Test.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[FormatFilter]
	public class UsersController : ControllerBase
	{
		private readonly IUserService userService;

		public UsersController(IUserService userService)
		{
			this.userService = userService;
		}

		[HttpGet(".{format?}")]
		public async Task<ActionResult> UserList()
		{
			var data = await userService.GetUsersList();
			var restrainedData = data.Select(RestrainIfNeeded);

			return Ok(restrainedData);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> UserData([FromRoute]int id)
		{
			var user = await userService.GetUserDataById(id);

			if (user == null)
				return NotFound();

			var restrainedUser = RestrainIfNeeded(user);

			return Ok(restrainedUser);
		}

		[HttpGet("{id}/albums")]
		public async Task<ActionResult> UserAlbums([FromRoute]int id)
		{
			return Ok(await userService.GetUserAlbums(id));
		}

		private UserDto RestrainIfNeeded(UserDto item)
		{
			return ShouldSeeSensitiveData(item)
				? item
				: userService.RestrainData(item);
		}

		private bool ShouldSeeSensitiveData(UserDto user)
		{
			var identityId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

			return identityId != null && identityId.Equals(user.Email);
		}
	}
}
