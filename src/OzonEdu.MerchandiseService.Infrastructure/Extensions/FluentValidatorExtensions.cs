using System;
using FluentValidation;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Infrastructure.Extensions
{
	/// <summary>
	/// Класс с расширениями для валидации Value Object через создание factory-методом.
	/// </summary>
	public static class FluentValidatorExtensions
	{
		public static IRuleBuilderOptions<T, TValue> MustBeValidObject<T, TValue, TValueObject>(
			this IRuleBuilder<T, TValue> ruleBuilder,
			Func<TValue, TValueObject> factoryMethod) where TValueObject : ValueObject
			=> (IRuleBuilderOptions<T, TValue>) ruleBuilder.Custom((value, context) =>
			{
				try
				{
					factoryMethod(value);
				}
				catch (InvalidValueObjectException ex)
				{
					context.AddFailure(ex.Message);
				}
			});
	}
}