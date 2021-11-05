using System.Collections.Generic;
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
		public Email(string name)
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