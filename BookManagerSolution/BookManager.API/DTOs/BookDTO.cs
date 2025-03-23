namespace BookManager.API.DTOs
{
	public class BookDTO
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public int Year { get; set; }
		public string Genre { get; set; } = string.Empty;
		public int PageCount { get; set; }
		public int AuthorId { get; set; }
		public string AuthorName { get; set; } = string.Empty;
	}
}
