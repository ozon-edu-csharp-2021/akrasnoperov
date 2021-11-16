using System.Collections.Generic;
using System.Text.RegularExpressions;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
	/// <summary>
	/// ValueObject, описывающий электронную почту.
	/// </summary>
	public class Email : ValueObject
	{
		/// <summary>
		/// Сам адрес электронной почты.
		/// </summary>
		public string Value { get; }

		/// <summary>
		/// .ctor
		/// </summary>
		private Email(string name)
		{
			Value = name;
		}

		/// <inheritdoc />
		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}

		/// <summary>
		/// Создает <see cref="Email"/>.
		/// </summary>
		/// <param name="emailStr">Электронная почта, из которой нужно создать объект.</param>
		/// <returns>Созданный объект <see cref="Email"/></returns>
		/// <exception cref="InvalidValueObjectException"></exception>
		public static Email Create(string emailStr)
		{
			var (isValid, error) = IsValid(emailStr);
			if (isValid)
			{
				return new Email(emailStr);
			}

			throw new InvalidValueObjectException(error);
		}

		private static (bool isValid, string error) IsValid(string? emailStr)
		{
			if (string.IsNullOrWhiteSpace(emailStr))
			{
				return (false, "Email should not be null or empty");
			}

			if (!Regex.IsMatch(emailStr, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
			{
				return (false, $"Email is invalid: {emailStr}");
			}

			return (true, string.Empty);
		}
	}
}