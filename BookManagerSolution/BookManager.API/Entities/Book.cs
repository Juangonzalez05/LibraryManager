using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManager.API.Entities
{
	public class Book
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(200)]
		public string Title { get; set; } = string.Empty;

		[Required]
		public int Year { get; set; }

		[Required]
		[MaxLength(50)]
		public string Genre { get; set; } = string.Empty;

		[Required]
		public int PageCount { get; set; }

		[Required]
		public int AuthorId { get; set; }

		[ForeignKey("AuthorId")]
		public Author? Author { get; set; }
	}
}
