using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Infrastructure.Stubs
{
	/// <summary>
	/// Заглушка для <see cref="IIssuedMerchRepository"/>.
	/// </summary>
	public class IssuedMerchRepository : IIssuedMerchRepository
	{
		/// <inheritdoc />
		public IUnitOfWork UnitOfWork { get; }

		/// <summary>
		/// .ctor
		/// </summary>
		public IssuedMerchRepository(IUnitOfWork unitOfWork)
		{
			UnitOfWork = unitOfWork;
		}

		/// <inheritdoc />
		public Task<IssuedMerch?> FindByIdAsync(long entityId, CancellationToken ct = default)
		{
			throw new System.NotImplementedException();
		}

		/// <inheritdoc />
		public Task<IssuedMerch> CreateAsync(IssuedMerch itemToCreate, CancellationToken ct = default)
		{
			return Task.FromResult(itemToCreate);
		}

		/// <inheritdoc />
		public Task<IssuedMerch> UpdateAsync(IssuedMerch itemToUpdate, CancellationToken ct = default)
		{
			throw new System.NotImplementedException();
		}

		/// <inheritdoc />
		public Task<IReadOnlyCollection<IssuedMerch>> GetIssuedMerches(
			long employeeId,
			CancellationToken ct = default)
		{
			var employee = new Employee(ClothingSize.L, Email.Create("email@ozon.ru"));
			return Task.FromResult<IReadOnlyCollection<IssuedMerch>>(new List<IssuedMerch>
			{
				new (new DateTimeOffset(new DateTime(2021, 01, 01), TimeSpan.FromHours(3)),
					Quantity.Create(1),
					Status.Issued,
					new Merch(2, Sku.Create(12), Name.Create("Мерч_1"), MerchType.Notepad),
					employee),
				new (new DateTimeOffset(new DateTime(2021, 01, 01), TimeSpan.FromHours(3)),
					Quantity.Create(3),
					Status.Issued,
					new Merch(3, Sku.Create(13), Name.Create("Мерч_2"), MerchType.Notepad),
					employee),
				new (new DateTimeOffset(new DateTime(2021, 07, 05), TimeSpan.FromHours(3)),
					Quantity.Create(1),
					Status.ReadyToIssue,
					new Merch(4, Sku.Create(14), Name.Create("Мерч_3"), MerchType.Bag),
					employee)
			});
		}
	}
}