using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Infrastructure.Stubs
{
	/// <summary>
	/// Заглушка для <see cref="IMerchRepository"/>.
	/// </summary>
	public class MerchRepository : IMerchRepository
	{
		/// <inheritdoc />
		public IUnitOfWork UnitOfWork { get; }

		/// <inheritdoc />
		public Task<Merch?> FindByIdAsync(int entityId, CancellationToken ct = default)
		{
			throw new System.NotImplementedException();
		}

		/// <inheritdoc />
		public Task<Merch> CreateAsync(Merch itemToCreate, CancellationToken ct = default)
		{
			throw new System.NotImplementedException();
		}

		/// <inheritdoc />
		public Task<Merch> UpdateAsync(Merch itemToUpdate, CancellationToken ct = default)
		{
			throw new System.NotImplementedException();
		}

		/// <inheritdoc />
		public Task<Merch?> FindBySkuAsync(Sku sku, CancellationToken ct = default)
		{
			return Task.FromResult<Merch?>(new Merch(sku, new Name("Супер ручка"), MerchType.Pen));
		}
	}
}