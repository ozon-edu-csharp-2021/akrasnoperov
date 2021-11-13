using System;
using FluentAssertions;
using OzonEdu.MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.ValueObjects
{
	/// <summary>
	/// Тесты для VO <see cref="Quantity"/>.
	/// </summary>
	[Trait("Category", "Unit")]
	public class QuantityTests
	{
		[Theory]
		[InlineData(1)]
		[InlineData(1_000)]
		[InlineData(999_999)]
		[InlineData(int.MaxValue)]
		public void CreateValidObject(int quantity)
		{
			var result = Quantity.Create(quantity);

			result.Should().NotBeNull();
			result.Value.Should().Be(quantity);
		}

		[Theory]
		[InlineData(0, "Quantity should be more than 0: 0")]
		[InlineData(-1, "Quantity should be more than 0: -1")]
		[InlineData(-1_000, "Quantity should be more than 0: -1000")]
		public void CreateInvalidObject(
			int quantity,
			string errorMessage)
		{
			Action act = () => Quantity.Create(quantity);

			act.Should().Throw<InvalidValueObjectException>().WithMessage(errorMessage);
		}
	}
}