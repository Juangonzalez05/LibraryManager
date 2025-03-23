using System;

namespace BookManager.API.Exceptions
{
	public class BookLimitExceededException : Exception
	{
		public BookLimitExceededException() : base("No es posible registrar el libro, se alcanzó el máximo permitido.") { }
	}
}
