using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate
{
	/// <summary>
	/// Репозиторий для работы с <see cref="IssuedMerch"/>.
	/// </summary>
	public interface IIssuedMerchRepository : IRepository<IssuedMerch>
	{
		/// <summary>
		/// Возвращает список <see cref="IssuedMerch"/> по <paramref name="employeeId"/>.
		/// </summary>
		/// <param name="employeeId">Идентификатор сотрудника.</param>
		/// <param name="ct">Токен для отмены операции <see cref="CancellationToken"/></param>
		/// <returns>Список сущностей <see cref="IssuedMerch"/>.</returns>
		Task<IReadOnlyCollection<IssuedMerch>> GetIssuedMerches(
			int employeeId,
			CancellationToken ct = default);
	}
}