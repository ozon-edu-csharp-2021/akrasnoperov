using System;
using System.Collections.Generic;
using FluentAssertions;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchandiseService.Domain.Exceptions.EmployeeAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests
{
	/// <summary>
	/// Тесты для <see cref="Employee"/>.
	/// </summary>
	[Trait("Category", "Unit")]
	public class EmployeeTests
	{
		#region AddIssuedMerch

		[Fact]
		public void AddIssuedMerchToEmployeeWithEmptyIssuedMerch()
		{
			var sut = new Employee(ClothingSize.L);
			var merch = new Merch(
				new Sku(123),
				new Name("Name"),
				MerchType.Bag,
				new Quantity(1));

			sut.AddIssuedMerch(merch, DateTimeOffset.UtcNow);
			var result = sut.GetIssuedMerches();

			result.Count.Should().Be(1);
			result.Should().Contain(_ => _.Key.MerchType.Equals(merch.MerchType));
		}

		[Fact]
		public void AddIssuedMerchToEmployeeWithNoEmptyIssuedMerch()
		{
			var sut = new Employee(ClothingSize.L);
			var issuedMerch = new Merch(
				new Sku(123),
				new Name("Name"),
				MerchType.Bag,
				new Quantity(1));
			sut.IssuedMerches = new Dictionary<Merch, DateTimeOffset>
			{
				{ issuedMerch, DateTimeOffset.UtcNow }
			};
			var merch = new Merch(
				new Sku(1234),
				new Name("Name"),
				MerchType.Notepad,
				new Quantity(1));

			sut.AddIssuedMerch(merch, DateTimeOffset.UtcNow);
			var result = sut.GetIssuedMerches();

			result.Count.Should().Be(2);
			result.Should().Contain(_ => _.Key.MerchType.Equals(merch.MerchType));
			result.Should().Contain(_ => _.Key.MerchType.Equals(issuedMerch.MerchType));
		}

		[Theory]
		[InlineData(365)]
		[InlineData(366)]
		[InlineData(400)]
		public void AddIssuedMerchToEmployeeWithIssuedMerch1YearAndMoreAgo365DaysInYear(int daysCount)
		{
			var sut = new Employee(ClothingSize.L);
			var merchIssuedDate = new DateTimeOffset(new DateTime(2021, 01, 01), TimeSpan.Zero);
			var issuedMerch = new Merch(
				new Sku(123),
				new Name("Name"),
				MerchType.Notepad,
				new Quantity(1));
			sut.IssuedMerches = new Dictionary<Merch, DateTimeOffset>
			{
				{ issuedMerch, merchIssuedDate }
			};
			var merch = new Merch(
				new Sku(123),
				new Name("Name"),
				MerchType.Notepad,
				new Quantity(1));

			sut.AddIssuedMerch(merch, merchIssuedDate.AddDays(daysCount));
			var result = sut.GetIssuedMerches();

			result.Count.Should().Be(2);
			result.Should().Contain(_ => _.Key.MerchType.Equals(merch.MerchType));
			result.Should().Contain(_ => _.Key.MerchType.Equals(issuedMerch.MerchType));
		}

		[Theory]
		[InlineData(366)]
		[InlineData(400)]
		public void AddIssuedMerchToEmployeeWithIssuedMerch1YearAndMoreAgo366DaysInYear(int daysCount)
		{
			var sut = new Employee(ClothingSize.L);
			var merchIssuedDate = new DateTimeOffset(new DateTime(2020, 01, 01), TimeSpan.Zero);
			var issuedMerch = new Merch(
				new Sku(123),
				new Name("Name"),
				MerchType.Notepad,
				new Quantity(1));
			sut.IssuedMerches = new Dictionary<Merch, DateTimeOffset>
			{
				{ issuedMerch, merchIssuedDate }
			};
			var merch = new Merch(
				new Sku(123),
				new Name("Name"),
				MerchType.Notepad,
				new Quantity(1));

			sut.AddIssuedMerch(merch, merchIssuedDate.AddDays(daysCount));
			var result = sut.GetIssuedMerches();

			result.Count.Should().Be(2);
			result.Should().Contain(_ => _.Key.MerchType.Equals(merch.MerchType));
			result.Should().Contain(_ => _.Key.MerchType.Equals(issuedMerch.MerchType));
		}

		[Theory]
		[InlineData(364)]
		[InlineData(363)]
		[InlineData(300)]
		public void AddIssuedMerchToEmployeeWithIssuedMerchLessThan1YearAgo365DaysInYear(int daysCount)
		{
			var sut = new Employee(ClothingSize.L);
			var merchIssuedDate = new DateTimeOffset(new DateTime(2021, 01, 01), TimeSpan.Zero);
			var issuedMerch = new Merch(
				new Sku(123),
				new Name("Name"),
				MerchType.Notepad,
				new Quantity(1));
			sut.IssuedMerches = new Dictionary<Merch, DateTimeOffset>
			{
				{ issuedMerch, merchIssuedDate }
			};
			var merch = new Merch(
				new Sku(123),
				new Name("Name"),
				MerchType.Notepad,
				new Quantity(1));

			Action act = () => sut.AddIssuedMerch(merch, merchIssuedDate.AddDays(daysCount));

			act.Should().Throw<IssueIssuedMerchException>()
				.WithMessage("С момента выдачи мерча типа Notepad прошло меньше года.");
		}

		[Theory]
		[InlineData(365)]
		[InlineData(364)]
		[InlineData(363)]
		[InlineData(300)]
		public void AddIssuedMerchToEmployeeWithIssuedMerchLessThan1YearAgo366DaysInYear(int daysCount)
		{
			var sut = new Employee(ClothingSize.L);
			var merchIssuedDate = new DateTimeOffset(new DateTime(2020, 01, 01), TimeSpan.Zero);
			var issuedMerch = new Merch(
				new Sku(123),
				new Name("Name"),
				MerchType.Notepad,
				new Quantity(1));
			sut.IssuedMerches = new Dictionary<Merch, DateTimeOffset>
			{
				{ issuedMerch, merchIssuedDate }
			};
			var merch = new Merch(
				new Sku(123),
				new Name("Name"),
				MerchType.Notepad,
				new Quantity(1));

			Action act = () => sut.AddIssuedMerch(merch, merchIssuedDate.AddDays(daysCount));

			act.Should().Throw<IssueIssuedMerchException>()
				.WithMessage("С момента выдачи мерча типа Notepad прошло меньше года.");
		}

		[Fact]
		public void AddIssuedMerchToEmployeeWithWrongClothingSize()
		{
			var sut = new Employee(ClothingSize.L);
			var merch = new Merch(
				new Sku(123),
				new Name("Name"),
				MerchType.Sweatshirt,
				new Quantity(1),
				ClothingSize.M);

			Action act = () => sut.AddIssuedMerch(merch, DateTimeOffset.UtcNow);

			act.Should().Throw<WrongClothingSizeException>()
				.WithMessage("Размер одежды сотрудника L не совпадает с размером мерча M.");
		}

		#endregion

		#region GetIssuedMerches

		[Fact]
		public void GetIssuedMerchesWithEmptyIssuedMerch()
		{
			var sut = new Employee(ClothingSize.L);

			var result = sut.GetIssuedMerches();

			result.Should().BeEmpty();
		}

		[Fact]
		public void GetIssuedMerchesWithWithNoEmptyIssuedMerch()
		{
			var sut = new Employee(ClothingSize.L);
			var issuedMerch1 = new Merch(
				new Sku(123),
				new Name("Name"),
				MerchType.Bag,
				new Quantity(1));
			var issuedMerch2 = new Merch(
				new Sku(1234),
				new Name("Name"),
				MerchType.Notepad,
				new Quantity(1));
			sut.IssuedMerches = new Dictionary<Merch, DateTimeOffset>
			{
				{ issuedMerch1, DateTimeOffset.UtcNow },
				{ issuedMerch2, DateTimeOffset.UtcNow }
			};

			var result = sut.GetIssuedMerches();

			result.Should().NotBeNullOrEmpty();
			result.Count.Should().Be(2);
			result.Should().Contain(_ => _.Key.Sku.Equals(issuedMerch1.Sku));
			result.Should().Contain(_ => _.Key.Sku.Equals(issuedMerch2.Sku));
		}

		#endregion
	}
}