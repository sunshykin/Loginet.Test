using System.Threading.Tasks;
using Loginet.Test.Entities;

namespace Loginet.Test.Interfaces
{
	public interface IUserRepository : IRepository<User>
	{
		public Task<User> GetByEmailAsync(string email);
	}
}