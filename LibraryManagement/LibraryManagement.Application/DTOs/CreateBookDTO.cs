using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.DTOs
{
    public class CreateBookDTO
    {
		public required string Title { get; set; }
		public required string Genre { get; set; }
		public int Year { get; set; }
		public int PageCount { get; set; }
		public int AuthorId { get; set; }
	}
}
