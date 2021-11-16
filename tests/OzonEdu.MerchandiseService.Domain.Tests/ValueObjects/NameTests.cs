using System;
using FluentAssertions;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.ValueObjects
{
	/// <summary>
	/// Тесты для VO <see cref="Name"/>.
	/// </summary>
	[Trait("Category", "Unit")]
	public class NameTests
	{
		[Theory]
		[InlineData("Наименование 1")]
		[InlineData("Имя_2")]
		[InlineData("Имечко")]
		[InlineData("name")]
		[InlineData("best_name_in_the_world123")]
		public void CreateValidObject(string nameStr)
		{
			var result = Name.Create(nameStr);

			result.Should().NotBeNull();
			result.Value.Should().Be(nameStr);
		}

		[Theory]
		[InlineData("Очень длинное имя, длина которого больше 50 символов", "Length of name should be equal or less than 50: Очень длинное имя, длина которого больше 50 символов")]
		[InlineData(" ", "Name should not be null or empty")]
		[InlineData("", "Name should not be null or empty")]
		[InlineData(null, "Name should not be null or empty")]
		public void CreateInvalidObject(
			string emailStr,
			string errorMessage)
		{
			Action act = () => Name.Create(emailStr);

			act.Should().Throw<InvalidValueObjectException>().WithMessage(errorMessage);
		}
	}
}