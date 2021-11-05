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

		/// <inheritdoc />
		public Task<IssuedMerch?> FindByIdAsync(int entityId, CancellationToken ct = default)
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
			int employeeId,
			CancellationToken ct = default)
		{
			var employee = new Employee(ClothingSize.L, new Email("email@ozon.ru"));
			return Task.FromResult<IReadOnlyCollection<IssuedMerch>>(new List<IssuedMerch>
			{
				new (new DateTimeOffset(new DateTime(2021, 01, 01), TimeSpan.FromHours(3)),
					new Quantity(1),
					Status.Issued,
					new Merch(new Sku(12), new Name("Мерч 1"), MerchType.Notepad),
					employee),
				new (new DateTimeOffset(new DateTime(2021, 01, 01), TimeSpan.FromHours(3)),
					new Quantity(3),
					Status.Issued,
					new Merch(new Sku(13), new Name("Мерч 2"), MerchType.Notepad),
					employee),
				new (new DateTimeOffset(new DateTime(2021, 07, 05), TimeSpan.FromHours(3)),
					new Quantity(1),
					Status.ReadyToIssue,
					new Merch(new Sku(14), new Name("Мерч 3"), MerchType.Bag),
					employee)
			});
		}
	}
}