using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchandiseService.Domain.Exceptions.EmployeeAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.IssuedMerchAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.IssuedMerchAggregate
{
	/// <summary>
	/// Handler для Query <see cref="IssueMerchCommand"/>.
	/// </summary>
	public class IssueMerchCommandHandler : IRequestHandler<IssueMerchCommand, IssuedMerch>
	{
		private readonly IMerchRepository _merchRepository;
		private readonly IEmployeeRepository _employeeRepository;
		private readonly IIssuedMerchRepository _issuedMerchRepository;

		/// <summary>
		/// .ctor
		/// </summary>
		public IssueMerchCommandHandler(
			IMerchRepository merchRepository,
			IEmployeeRepository employeeRepository,
			IIssuedMerchRepository issuedMerchRepository)
		{
			_merchRepository = merchRepository;
			_employeeRepository = employeeRepository;
			_issuedMerchRepository = issuedMerchRepository;
		}

		/// <inheritdoc />
		public async Task<IssuedMerch> Handle(
			IssueMerchCommand request,
			CancellationToken cancellationToken)
		{
			var utcNow = DateTimeOffset.Now;
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

			var merch = await _merchRepository.FindBySkuAsync(Sku.Create(request.Sku), cancellationToken);
			if (merch is null)
			{
				// TODO: Получить из сервиса stock-api информацию о товаре по SKU, записать в БД новый мерч.
				// Если такого товара нет, выбросить исключение.
				merch = await _merchRepository.CreateAsync(
					new Merch(Sku.Create(request.Sku), Name.Create("ПОЛУЧЕННОЕ_ИМЯ"), MerchType.Bag),
					cancellationToken);
				await _merchRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
			}

			// Размер одежды сотрудника и размер мерча не совпадают.
			if (!employee.IsMerchFit(merch))
			{
				throw new WrongClothingSizeException(employee.ClothingSize, merch.ClothingSize!);
			}

			if (employee.HasIssuedMerch(merch, utcNow))
			{
				throw new IssueIssuedMerchException(merch.MerchType);
			}

			// TODO: Получить из сервиса stock-api информацию о наличии необходимого количества товара по SKU.
			// Если товара нет, то записать статус выдачи Waiting.
			var status = Status.ReadyToIssue;

			var result = await _issuedMerchRepository.CreateAsync(
				new IssuedMerch(
					utcNow,
					Quantity.Create(request.Quantity),
					status,
					merch,
					employee),
				cancellationToken);

			await _issuedMerchRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

			return result;
		}
	}
}