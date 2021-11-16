using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Infrastructure.Stubs
{
	/// <summary>
	/// Заглушка для <see cref="IUnitOfWork"/>
	/// </summary>
	public class UnitOfWork : IUnitOfWork
	{
		/// <inheritdoc />
		public Task<int> SaveChangesAsync(CancellationToken ct = default)
		{
			return Task.FromResult(1);
		}

		/// <inheritdoc />
		public Task<bool> SaveEntitiesAsync(CancellationToken ct = default)
		{
			return Task.FromResult(true);
		}
	}
}