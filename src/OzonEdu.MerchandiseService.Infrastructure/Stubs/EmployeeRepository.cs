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

		/// <summary>
		/// .ctor
		/// </summary>
		public EmployeeRepository(IUnitOfWork unitOfWork)
		{
			UnitOfWork = unitOfWork;
		}

		/// <inheritdoc />
		public Task<Employee?> FindByIdAsync(long entityId, CancellationToken ct = default)
		{
			return Task.FromResult(new Employee(ClothingSize.L, Email.Create("employee1@ozon.ru")))!;
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