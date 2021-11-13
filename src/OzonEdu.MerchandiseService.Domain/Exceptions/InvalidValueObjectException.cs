using System;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.Exceptions
{
	/// <summary>
	/// Исключение для валидации <see cref="ValueObject"/>.
	/// </summary>
	public class InvalidValueObjectException : Exception
	{
		/// <summary>
		/// .ctor
		/// </summary>
		public InvalidValueObjectException(string message) : base(message)
		{
		}
	}
}