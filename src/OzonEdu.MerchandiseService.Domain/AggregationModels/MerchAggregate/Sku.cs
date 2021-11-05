using System.Collections.Generic;
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
		/// </summary>
		public long Value { get; }

		/// <summary>
		/// .ctor
		/// </summary>
		public Sku(long sku)
		{
			Value = sku;
		}

		/// <inheritdoc />
		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}
}