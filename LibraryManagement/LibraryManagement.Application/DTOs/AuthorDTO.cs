using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.DTOs
{
    public class AuthorDTO
    {
		public int Id { get; set; }
		public required string FullName { get; set; }
		public DateTime BirthDate { get; set; }
		public required string City { get; set; }
		public required string Email { get; set; }
	}
}
