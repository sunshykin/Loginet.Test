using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Loginet.Test.Dto;
using Loginet.Test.Entities;
using Loginet.Test.Interfaces;

namespace Loginet.Test.Services
{
	public class UserService : IUserService
	{
		private readonly IMapper mapper;

		private readonly IUserRepository userRepository;

		private readonly IAlbumRepository albumRepository;

		public UserService(IMapper mapper, IUserRepository userRepository, IAlbumRepository albumRepository)
		{
			this.mapper = mapper;

			this.userRepository = userRepository;
			this.albumRepository = albumRepository;
		}

		public async Task<IEnumerable<UserDto>> GetUsersList()
		{
			var data = await userRepository.GetListAsync();

			return mapper.Map<IEnumerable<User>, IEnumerable <UserDto>>(data);
		}

		public async Task<UserDto> GetUserDataById(int userId)
		{
			var data = await userRepository.GetByIdAsync(userId);

			return mapper.Map<User, UserDto>(data);
		}

		public async Task<UserDto> GetUserDataByEmail(string email)
		{
			var data = await userRepository.GetByEmailAsync(email);

			return mapper.Map<User, UserDto>(data);
		}

		public async Task<IEnumerable<AlbumDto>> GetUserAlbums(int userId)
		{
			var data = await albumRepository.GetUserAlbumsAsync(userId);

			return mapper.Map<IEnumerable<Album>, IEnumerable<AlbumDto>>(data);
		}

		public UserDto RestrainData(UserDto data)
		{
			return new UserDto
			{
				Id = data.Id,
				Name = data.Name,
				Website = data.Website
			};
		}
	}
}