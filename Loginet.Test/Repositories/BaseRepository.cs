using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loginet.Test.Entities;
using Loginet.Test.Interfaces;
using Loginet.Test.Misc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace Loginet.Test.Repositories
{
	public class BaseRepository<T>: IRepository<T> where T : class, IEntity
	{
		private readonly RestClient client;

		public BaseRepository(IOptions<RestClientConfiguration>  config)
		{
			client = new RestClient(config.Value.BaseAddress);
		}

		// Could be used as a Singleton, but I've decided, that overriding possibility is more powerful
		public virtual string EntityAddress => $"{typeof(T).Name}s".ToLower();

		protected RestRequest CreateGetRequest()
		{
			return new RestRequest(EntityAddress, Method.GET);
		}

		public async Task<IEnumerable<T>> GetListAsync()
		{
			var request = CreateGetRequest();

			// Not using ExecuteAsync<T> cause of its lack of reliability when Deserializing response
			// (It can just give you null with nothing said)
			var result = await client.ExecuteAsync(request);

			return JsonConvert.DeserializeObject<T[]>(result.Content);
		}

		public async Task<T> GetByIdAsync(int id)
		{
			// Cause of lack of flexibility with using External API we just pretend that we're requesting
			// only one entity
			var collection = await GetListAsync();

			return collection.FirstOrDefault(entity => entity.Id.Equals(id));
		}
	}
}