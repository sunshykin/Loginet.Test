using AutoMapper;
using Loginet.Test.Dto;
using Loginet.Test.Entities;
using Loginet.Test.Interfaces;
using Loginet.Test.Repositories;
using Loginet.Test.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Loginet.Test.Misc
{
	public static class StartupExtensions
	{
		public static void AddConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			// Configuring RestClient settings
			services.Configure<RestClientConfiguration>(options =>
			{
				options.BaseAddress =
					configuration.GetSection("Data:BaseAddress").Value;
			});
		}
		public static void AddMapper(this IServiceCollection services)
		{
			var mapperConfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<User, UserDto>();
				cfg.CreateMap<Album, AlbumDto>();
			});

			services.AddSingleton<IMapper>(mapperConfig.CreateMapper());
		}

		public static void AddRepositories(this IServiceCollection services)
		{
			services.AddSingleton<IUserRepository, UserRepository>();
			services.AddSingleton<IAlbumRepository, AlbumRepository>();
		}

		public static void AddServices(this IServiceCollection services)
		{
			services.AddSingleton<IUserService, UserService>();
			services.AddSingleton<IAlbumService, AlbumService>();
		}
	}
}
