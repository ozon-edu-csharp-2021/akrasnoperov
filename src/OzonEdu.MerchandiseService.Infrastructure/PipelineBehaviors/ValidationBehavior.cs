using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.PipelineBehaviors
{
	/// <summary>
	/// <see cref="IPipelineBehavior{TRequest, TResponse}"/>
	/// для валидации <typeparamref name="TRequest"/>.
	/// </summary>
	/// <typeparam name="TRequest">Тип запроса.</typeparam>
	/// <typeparam name="TResponse">Тип ответа.</typeparam>
	public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : class, IRequest<TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;

		/// <summary>
		/// .ctor
		/// </summary>
		public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
		{
			_validators = validators;
		}

		/// <inheritdoc />
		public async Task<TResponse> Handle(
			TRequest request,
			CancellationToken cancellationToken,
			RequestHandlerDelegate<TResponse> next)
		{
			if (!_validators.Any())
			{
				return await next();
			}

			var context = new ValidationContext<TRequest>(request);
			var validationFailures = _validators
				.Select(_ => _.Validate(context))
				.Where(_ => !_.IsValid)
				.SelectMany(_ => _.Errors)
				.Where(_ => _ != null).ToList();

			if (validationFailures.Any())
			{
				throw new ValidationException(validationFailures);
			}

			return await next();
		}
	}
}