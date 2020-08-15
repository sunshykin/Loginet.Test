using Newtonsoft.Json;

namespace Loginet.Test.Entities
{
	public class User : IEntity
	{
		public int Id { get; set; }

		public string Name { get; set; }

		[JsonProperty("username")]
		public string UserName { get; set; }

		public string Email { get; set; }
		
		public string Phone { get; set; }

		public string Website { get; set; }
	}
}