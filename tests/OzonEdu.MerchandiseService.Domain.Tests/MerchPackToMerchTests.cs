using System;
using FluentAssertions;
using OzonEdu.MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests
{
	/// <summary>
	/// Тесты для <see cref="MerchPackToMerch"/>.
	/// </summary>
	[Trait("Category", "Unit")]
	public class MerchPackToMerchTests
	{
		[Fact]
		public void CreateValidObject()
		{
			var random = new Random();
			var quantity = Quantity.Create(random.Next(1, 1_000));
			var merch = new Merch(random.Next(1, 1_000), Sku.Create(random.Next(1, 1_000)), Name.Create("Супер_ручка"), MerchType.Pen);
			var merchPack = new MerchPack(random.Next(1, 1_000), Name.Create("Супер мерч"));

			var result = new MerchPackToMerch(quantity, merch, merchPack);

			result.Should().NotBeNull();
			result.Quantity.Should().Be(quantity);
			result.Merch.Should().Be(merch);
			result.MerchPack.Should().Be(merchPack);
		}

		[Fact]
		public void CreateInvalidObjectWithNullQuantity()
		{
			var random = new Random();
			Quantity quantity = null;
			var merch = new Merch(random.Next(1, 1_000), Sku.Create(random.Next(1, 1_000)), Name.Create("Супер_ручка"), MerchType.Pen);
			var merchPack = new MerchPack(random.Next(1, 1_000), Name.Create("Супер мерч"));

			Action act = () => new MerchPackToMerch(quantity, merch, merchPack);

			act.Should().Throw<ArgumentNullException>().WithMessage("quantity should not be null (Parameter 'quantity')");
		}

		[Fact]
		public void CreateInvalidObjectWithNullMerch()
		{
			var random = new Random();
			var quantity = Quantity.Create(random.Next(1, 1_000));
			Merch merch = null;
			var merchPack = new MerchPack(random.Next(1, 1_000), Name.Create("Супер мерч"));

			Action act = () => new MerchPackToMerch(quantity, merch, merchPack);

			act.Should().Throw<ArgumentNullException>().WithMessage("merch should not be null (Parameter 'merch')");
		}

		[Fact]
		public void CreateInvalidObjectWithNullMerchPack()
		{
			var random = new Random();
			var quantity = Quantity.Create(random.Next(1, 1_000));
			var merch = new Merch(random.Next(1, 1_000), Sku.Create(random.Next(1, 1_000)), Name.Create("Супер_ручка"), MerchType.Pen);
			MerchPack merchPack = null;

			Action act = () => new MerchPackToMerch(quantity, merch, merchPack);

			act.Should().Throw<ArgumentNullException>().WithMessage("merchPack should not be null (Parameter 'merchPack')");
		}
	}
}