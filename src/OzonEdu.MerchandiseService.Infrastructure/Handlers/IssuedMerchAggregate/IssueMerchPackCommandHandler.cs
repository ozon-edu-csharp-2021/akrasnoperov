using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchandiseService.Domain.Models;
using OzonEdu.MerchandiseService.Infrastructure.Commands.IssuedMerchAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Exceptions;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.IssuedMerchAggregate
{
	/// <summary>
	/// Handler для Query <see cref="IssueMerchPackCommand"/>.
	/// </summary>
	public class IssueMerchPackCommandHandler : IRequestHandler<IssueMerchPackCommand, IReadOnlyCollection<IssuedMerch>>
	{
		private readonly IMediator _mediator;
		private readonly IMerchRepository _merchRepository;
		private readonly IEmployeeRepository _employeeRepository;

		/// <summary>
		/// .ctor
		/// </summary>
		public IssueMerchPackCommandHandler(
			IMediator mediator,
			IMerchRepository merchRepository,
			IEmployeeRepository employeeRepository)
		{
			_mediator = mediator;
			_merchRepository = merchRepository;
			_employeeRepository = employeeRepository;
		}

		/// <inheritdoc />
		public async Task<IReadOnlyCollection<IssuedMerch>> Handle(
			IssueMerchPackCommand request,
			CancellationToken cancellationToken)
		{
			var merchPackTypes = Enumeration.GetAll<MerchPackType>();
			var merchPackType = merchPackTypes.SingleOrDefault(_ => _.Id == request.MerchPackId);
			if (merchPackType == null)
			{
				throw new EntityNotFoundException($"Не нашли мерч пак с идентификатором {request.MerchPackId}");
			}
			// TODO: Убрать дублирование с IssueMerchCommandHandler.
			var employee = await _employeeRepository.FindByIdAsync(request.EmployeeId, cancellationToken);
			if (employee is null)
			{
				// TODO: Получить из сервиса employee-service информацию о сотруднике по идентификатору, записать в БД нового сотрудника.
				// Если такого сотрудника нет, выбросить исключение.
				employee = await _employeeRepository.CreateAsync(
					new Employee(ClothingSize.L, Email.Create("email@ozon.ru")),
					cancellationToken);
				await _employeeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
			}

			var merchesToIssue = await _merchRepository.GetMerchPackComposition(
				merchPackType,
				employee.ClothingSize,
				cancellationToken);

			var result = new List<IssuedMerch>();
			foreach (var (merch, quantity) in merchesToIssue)
			{
				var command = new IssueMerchCommand
				{
					Quantity = quantity,
					EmployeeId = request.EmployeeId,
					Sku = merch.Sku.Value
				};
				var issuedMerch = await _mediator.Send(command, cancellationToken);
				result.Add(issuedMerch);
			}

			return result;
		}
	}
}