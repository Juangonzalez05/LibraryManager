namespace BookManager.Blazor.Models
{
	public class Author
	{
		public int Id { get; set; }
		public string FullName { get; set; } = string.Empty;
		public DateTime DateOfBirth { get; set; }
		public string City { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
	}

	public class CreateAuthorDTO
	{
		public string FullName { get; set; } = string.Empty;
		public DateTime DateOfBirth { get; set; }
		public string City { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
	}

	public class UpdateAuthorDTO
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string City { get; set; }
		public string Email { get; set; }
	}
}
