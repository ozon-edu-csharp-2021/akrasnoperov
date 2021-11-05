using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Domain.Contracts
{
	/// <summary>
	/// Базовый интерфейс репозитория.
	/// </summary>
	/// <typeparam name="TAggregationRoot">Объект сущности для управления.</typeparam>
	public interface IRepository<TAggregationRoot>
	{
		/// <summary>
		/// Объект <see cref="IUnitOfWork"/>.
		/// </summary>
		IUnitOfWork UnitOfWork { get; }

		/// <summary>
		/// Возвращает сущность по ее идентификатору <paramref name="entityId"/>.
		/// </summary>
		/// <param name="entityId">Идентификатор сущности.</param>
		/// <param name="ct">Токен для отмены операции <see cref="CancellationToken"/></param>
		/// <returns>Существующая сущность <see cref="TAggregationRoot"/>.</returns>
		Task<TAggregationRoot?> FindByIdAsync(
			int entityId,
			CancellationToken ct = default);

		/// <summary>
		/// Создает новую сущность.
		/// </summary>
		/// <param name="itemToCreate">Объект для создания <see cref="TAggregationRoot"/>.</param>
		/// <param name="ct">Токен для отмены операции <see cref="CancellationToken"/></param>
		/// <returns>Созданная сущность <see cref="TAggregationRoot"/>.</returns>
		Task<TAggregationRoot> CreateAsync(
			TAggregationRoot itemToCreate,
			CancellationToken ct = default);

		/// <summary>
		/// Обновляет существующую сущность.
		/// </summary>
		/// <param name="itemToUpdate">Объект для обновления <see cref="TAggregationRoot"/>.</param>
		/// <param name="ct">Токен для отмены операции <see cref="CancellationToken"/></param>
		/// <returns>Обновленная сущность <see cref="TAggregationRoot"/>.</returns>
		Task<TAggregationRoot> UpdateAsync(
			TAggregationRoot itemToUpdate,
			CancellationToken ct = default);
	}
}