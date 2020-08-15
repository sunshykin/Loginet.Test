using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Loginet.Test.Dto;
using Loginet.Test.Entities;
using Loginet.Test.Interfaces;

namespace Loginet.Test.Services
{
	public class AlbumService : IAlbumService
	{
		private readonly IMapper mapper;

		private readonly IAlbumRepository albumRepository;

		public AlbumService(IMapper mapper, IAlbumRepository albumRepository)
		{
			this.mapper = mapper;

			this.albumRepository = albumRepository;
		}

		public async Task<IEnumerable<AlbumDto>> GetAlbumsList()
		{
			var data = await albumRepository.GetListAsync();

			return mapper.Map<IEnumerable<Album>, IEnumerable<AlbumDto>>(data);
		}

		public async Task<AlbumDto> GetAlbumById(int userId)
		{
			var data = await albumRepository.GetByIdAsync(userId);

			return mapper.Map<Album, AlbumDto>(data);
		}
	}
}