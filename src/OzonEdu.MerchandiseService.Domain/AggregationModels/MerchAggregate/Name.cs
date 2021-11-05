using System.Collections.Generic;
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
		public Name(string name)
		{
			Value = name;
		}

		/// <inheritdoc />
		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}
}