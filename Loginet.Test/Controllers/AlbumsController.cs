using System.Threading.Tasks;
using Loginet.Test.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Loginet.Test.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AlbumsController : ControllerBase
	{
		private readonly IAlbumService albumService;

		public AlbumsController(IAlbumService albumService)
		{
			this.albumService = albumService;
		}

		[HttpGet("")]
		public async Task<ActionResult> AlbumList()
		{
			return Ok(await albumService.GetAlbumsList());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> UserData([FromRoute] int id)
		{
			return Ok(await albumService.GetAlbumById(id));
		}
	}
}
