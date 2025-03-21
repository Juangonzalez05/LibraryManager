using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities
{
    public class Author
    {
		public int Id { get; set; }
		public string FullName { get; set; } = string.Empty; // 🔹 Evita el error al asignar un valor por defecto
		public DateTime BirthDate { get; set; }
		public string City { get; set; } = string.Empty; // 🔹 Soluciona el error de 'City'
		public string Email { get; set; } = string.Empty; // 🔹 Soluciona el error de 'Email'
		public List<Book> Books { get; set; } = new List<Book>();
	}
}
