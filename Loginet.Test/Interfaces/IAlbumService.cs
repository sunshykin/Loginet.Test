using System.Collections.Generic;
using System.Threading.Tasks;
using Loginet.Test.Dto;

namespace Loginet.Test.Interfaces
{
	public interface IAlbumService
	{
		public Task<IEnumerable<AlbumDto>> GetAlbumsList();

		public Task<AlbumDto> GetAlbumById(int userId);
	}
}