using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.DTOs
{
    public class BookDTO
    {
		public int Id { get; set; }
		public required string Title { get; set; }
		public required string Genre { get; set; }
		public int Year { get; set; }
		public int PageCount { get; set; }
		public required string AuthorName { get; set; }
	}
}
