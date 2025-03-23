using System;

namespace BookManager.API.Exceptions
{
	public class AuthorNotFoundException : Exception
	{
		public AuthorNotFoundException() : base("El autor no está registrado.") { }
	}
}
