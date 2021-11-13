using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate
{
	/// <summary>
	/// ValueObject, описывающий количество Merch.
	/// </summary>
	public class Quantity : ValueObject
	{
		/// <summary>
		/// Само значение количества.
		/// </summary>
		public int Value { get; }

		/// <summary>
		/// .ctor
		/// </summary>
		private Quantity(int value)
		{
			Value = value;
		}

		/// <inheritdoc />
		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}

		/// <summary>
		/// Создает <see cref="Quantity"/>.
		/// </summary>
		/// <param name="quantityValue">Значение, из которого нужно создать объект.</param>
		/// <returns>Созданный объект <see cref="Quantity"/></returns>
		/// <exception cref="InvalidValueObjectException"></exception>
		public static Quantity Create(int quantityValue)
		{
			var (isValid, error) = IsValid(quantityValue);
			if (isValid)
			{
				return new Quantity(quantityValue);
			}

			throw new InvalidValueObjectException(error);
		}

		private static (bool isValid, string error) IsValid(int quantityValue)
		{
			if (quantityValue < 1)
			{
				return (false, $"Quantity should be more than 0: {quantityValue}");
			}

			return (true, string.Empty);
		}
	}
}