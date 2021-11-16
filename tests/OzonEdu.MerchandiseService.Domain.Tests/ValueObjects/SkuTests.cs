using System;
using FluentAssertions;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.ValueObjects
{
	/// <summary>
	/// Тесты для VO <see cref="Sku"/>.
	/// </summary>
	[Trait("Category", "Unit")]
	public class SkuTests
	{
		[Theory]
		[InlineData(1)]
		[InlineData(1_000)]
		[InlineData(999_999)]
		[InlineData(long.MaxValue)]
		public void CreateValidObject(long skuId)
		{
			var result = Sku.Create(skuId);

			result.Should().NotBeNull();
			result.Value.Should().Be(skuId);
		}

		[Theory]
		[InlineData(0, "Sku should be more than 0: 0")]
		[InlineData(-1, "Sku should be more than 0: -1")]
		[InlineData(-1_000, "Sku should be more than 0: -1000")]
		public void CreateInvalidObject(
			long skuId,
			string errorMessage)
		{
			Action act = () => Sku.Create(skuId);

			act.Should().Throw<InvalidValueObjectException>().WithMessage(errorMessage);
		}
	}
}