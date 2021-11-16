using System.Collections.Generic;
using FluentValidation;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.IssuedMerchAggregate
{
	/// <summary>
	/// Command для выдачи мерч пака сотруднику.
	/// </summary>
	public class IssueMerchPackCommand : IRequest<IReadOnlyCollection<IssuedMerch>>
	{
		/// <summary>
		/// Идентификатор сотрудника.
		/// </summary>
		public int EmployeeId { get; set; }

		/// <summary>
		/// Идентификатор мерч пака для выдачи.
		/// </summary>
		public long MerchPackId { get; set; }
	}

	/// <summary>
	/// Валидатор <see cref="AbstractValidator{T}"/>
	/// для <see cref="IssueMerchPackCommand"/>.
	/// </summary>
	public class IssueMerchPackCommandValidator : AbstractValidator<IssueMerchPackCommand>
	{
		/// <summary>
		/// .ctor
		/// </summary>
		public IssueMerchPackCommandValidator()
		{
			RuleFor(_ => _.EmployeeId).GreaterThan(0).WithMessage("EmployeeId should be more than 0");
			RuleFor(_ => _.MerchPackId).GreaterThan(0).WithMessage("MerchPackId should be more than 0");;
		}
	}
}