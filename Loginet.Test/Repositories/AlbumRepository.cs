using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loginet.Test.Entities;
using Loginet.Test.Interfaces;
using Loginet.Test.Misc;
using Microsoft.Extensions.Options;

namespace Loginet.Test.Repositories
{
	public class AlbumRepository: BaseRepository<Album>, IAlbumRepository
	{
		public AlbumRepository(IOptions<RestClientConfiguration> config) : base(config)
		{
		}

		public async Task<IEnumerable<Album>> GetUserAlbumsAsync(int userId)
		{
			// Still pretending, that we are filtering database-side
			var collection = await GetListAsync();

			return collection
				.Where(album => album.UserId.Equals(userId))
				.ToArray();
		}
	}
}