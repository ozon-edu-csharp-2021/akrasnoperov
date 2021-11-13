using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate
{
	/// <summary>
	/// ValueObject, описывающий название Merch.
	/// </summary>
	public class Name : ValueObject
	{
		/// <summary>
		/// Само значение названия.
		/// </summary>
		public string Value { get; }

		/// <summary>
		/// .ctor
		/// </summary>
		private Name(string name)
		{
			Value = name;
		}

		/// <inheritdoc />
		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}

		/// <summary>
		/// Создает <see cref="Name"/>.
		/// </summary>
		/// <param name="nameStr">Название, из которого нужно создать объект.</param>
		/// <returns>Созданный объект <see cref="Name"/></returns>
		/// <exception cref="InvalidValueObjectException"></exception>
		public static Name Create(string nameStr)
		{
			var (isValid, error) = IsValid(nameStr);
			if (isValid)
			{
				return new Name(nameStr);
			}

			throw new InvalidValueObjectException(error);
		}

		private static (bool isValid, string error) IsValid(string? nameStr)
		{
			if (string.IsNullOrWhiteSpace(nameStr))
			{
				return (false, "Name should not be null or empty");
			}

			if (nameStr.Length > 50)
			{
				return (false, $"Length of name should be equal or less than 50: {nameStr}");
			}

			return (true, string.Empty);
		}
	}
}