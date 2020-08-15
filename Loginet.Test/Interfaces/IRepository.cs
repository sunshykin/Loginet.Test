using System.Collections.Generic;
using System.Threading.Tasks;
using Loginet.Test.Entities;

namespace Loginet.Test.Interfaces
{
	public interface IRepository<T> where T : class, IEntity
	{
		public Task<IEnumerable<T>> GetListAsync();

		public Task<T> GetByIdAsync(int id);
	}
}