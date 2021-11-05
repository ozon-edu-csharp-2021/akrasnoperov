using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Infrastructure.Stubs
{
	/// <summary>
	/// Заглушка для <see cref="IEmployeeRepository"/>.
	/// </summary>
	public class EmployeeRepository : IEmployeeRepository
	{
		/// <inheritdoc />
		public IUnitOfWork UnitOfWork { get; }

		/// <inheritdoc />
		public Task<Employee> GetByIdAsync(
			int entityId,
			CancellationToken ct = default)
		{
			return Task.FromResult(new Employee(ClothingSize.M)
			{
				IssuedMerches = new Dictionary<Merch, DateTimeOffset>
				{
					{
						new Merch(
							new Sku(123),
							new Name("Классный рюкзачок"),
							MerchType.Bag,
							new Quantity(1)),
						new DateTimeOffset(new DateTime(2021, 05, 07), TimeSpan.FromHours(3))
					},
					{
						new Merch(
							new Sku(456),
							new Name("Четкий блокнотик"),
							MerchType.Notepad,
							new Quantity(1)),
						new DateTimeOffset(new DateTime(2021, 05, 07), TimeSpan.FromHours(3))
					},
					{
						new Merch(
							new Sku(789),
							new Name("Космическая футболка"),
							MerchType.TShirt,
							new Quantity(1),
							ClothingSize.M),
						new DateTimeOffset(new DateTime(2021, 07, 01), TimeSpan.FromHours(3))
					}
				}
			});
		}

		/// <inheritdoc />
		public Task<Employee> CreateAsync(Employee itemToCreate, CancellationToken ct = default)
		{
			throw new System.NotImplementedException();
		}

		/// <inheritdoc />
		public Task<Employee> UpdateAsync(Employee itemToUpdate, CancellationToken ct = default)
		{
			throw new System.NotImplementedException();
		}
	}
}