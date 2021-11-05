using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate
{
	/// <summary>
	/// Репозиторий для работы с <see cref="Merch"/>.
	/// </summary>
	public interface IMerchRepository : IRepository<Merch>
	{
		/// <summary>
		/// Возвращает <see cref="Merch"/> по <paramref name="sku"/>
		/// </summary>
		/// <param name="sku"><see cref="Sku"/>.</param>
		/// <param name="ct">Токен для отмены операции <see cref="CancellationToken"/></param>
		/// <returns><see cref="Merch"/>.</returns>
		Task<Merch?> FindBySkuAsync(Sku sku, CancellationToken ct = default);
	}
}