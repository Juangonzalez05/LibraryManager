namespace BookManager.API.DTOs
{
	public class AuthorDTO
	{
		public int Id { get; set; }
		public string FullName { get; set; } = string.Empty;
		public DateTime DateOfBirth { get; set; }
		public string City { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
	}
}
