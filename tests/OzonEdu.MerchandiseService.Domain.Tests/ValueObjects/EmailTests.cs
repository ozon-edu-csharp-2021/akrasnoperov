using System;
using FluentAssertions;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.ValueObjects
{
	/// <summary>
	/// Тесты для VO <see cref="Email"/>.
	/// </summary>
	[Trait("Category", "Unit")]
	public class EmailTests
	{
		[Theory]
		[InlineData("test1@ozon.ru")]
		[InlineData("test-2@yandex.ru")]
		[InlineData("test+3@gmail.com")]
		[InlineData("TEST.4@aol.com")]
		[InlineData("test'5@mail.ru")]
		public void CreateValidObject(string emailStr)
		{
			var result = Email.Create(emailStr);

			result.Should().NotBeNull();
			result.Value.Should().Be(emailStr);
		}

		[Theory]
		[InlineData("test1@@ozon.ru", "Email is invalid: test1@@ozon.ru")]
		[InlineData("test1@", "Email is invalid: test1@")]
		[InlineData("test1@ozon", "Email is invalid: test1@ozon")]
		[InlineData("@ozon.ru", "Email is invalid: @ozon.ru")]
		[InlineData(" ", "Email should not be null or empty")]
		[InlineData("", "Email should not be null or empty")]
		[InlineData(null, "Email should not be null or empty")]
		public void CreateInvalidObject(
			string emailStr,
			string errorMessage)
		{
			Action act = () => Email.Create(emailStr);

			act.Should().Throw<InvalidValueObjectException>().WithMessage(errorMessage);
		}
	}
}