using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate
{
	/// <summary>
	/// ValueObject, описывающий SKU.
	/// </summary>
	public class Sku : ValueObject
	{
		/// <summary>
		/// Численное значение, определяющее SKU.
		/// Складской идентификатор товарной позиции.
		/// </summary>
		public long Value { get; }

		/// <summary>
		/// .ctor
		/// </summary>
		private Sku(long sku)
		{
			Value = sku;
		}

		/// <inheritdoc />
		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}

		/// <summary>
		/// Создает <see cref="Sku"/>.
		/// </summary>
		/// <param name="skuId">Идентификатор, из которого нужно создать объект.</param>
		/// <returns>Созданный объект <see cref="Sku"/></returns>
		/// <exception cref="InvalidValueObjectException"></exception>
		public static Sku Create(long skuId)
		{
			var (isValid, error) = IsValid(skuId);
			if (isValid)
			{
				return new Sku(skuId);
			}

			throw new InvalidValueObjectException(error);
		}

		private static (bool isValid, string error) IsValid(long skuId)
		{
			if (skuId < 1)
			{
				return (false, $"Sku should be more than 0: {skuId}");
			}

			return (true, string.Empty);
		}
	}
}