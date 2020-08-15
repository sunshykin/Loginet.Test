using System.Collections.Generic;
using System.Threading.Tasks;
using Loginet.Test.Entities;

namespace Loginet.Test.Interfaces
{
	public interface IAlbumRepository : IRepository<Album>
	{
		public Task<IEnumerable<Album>> GetUserAlbumsAsync(int userId);
	}
}