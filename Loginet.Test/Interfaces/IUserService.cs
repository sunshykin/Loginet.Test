using System.Collections.Generic;
using System.Threading.Tasks;
using Loginet.Test.Dto;

namespace Loginet.Test.Interfaces
{
	public interface IUserService
	{
		public Task<IEnumerable<UserDto>> GetUsersList();

		public Task<UserDto> GetUserDataById(int userId);

		public Task<UserDto> GetUserDataByEmail(string email);

		public Task<IEnumerable<AlbumDto>> GetUserAlbums(int userId);

		public UserDto RestrainData(UserDto data);
	}
}