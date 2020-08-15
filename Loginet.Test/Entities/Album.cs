namespace Loginet.Test.Entities
{
	public class Album : IEntity
	{
		public int Id { get; set; }

		public int UserId { get; set; }

		public string Title { get; set; }
	}
}