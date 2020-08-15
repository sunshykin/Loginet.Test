using System;
using System.Linq;
using System.Threading.Tasks;
using Loginet.Test.Entities;
using Loginet.Test.Interfaces;
using Loginet.Test.Misc;
using Microsoft.Extensions.Options;

namespace Loginet.Test.Repositories
{
	public class UserRepository: BaseRepository<User>, IUserRepository
	{
		public UserRepository(IOptions<RestClientConfiguration> config) : base(config)
		{
		}

		public async Task<User> GetByEmailAsync(string email)
		{
			var collection = await GetListAsync();

			return collection.FirstOrDefault(entity => entity.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));
		}
	}
}