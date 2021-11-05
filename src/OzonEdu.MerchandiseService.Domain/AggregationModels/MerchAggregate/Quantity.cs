using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate
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
		public Quantity(int value)
		{
			Value = value;
		}

		/// <inheritdoc />
		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}
}