using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Domain.Contracts
{
	/// <summary>
	/// See https://github.com/dotnet-architecture/eShopOnContainers/blob/dev/src/Services/Ordering/Ordering.Domain/SeedWork/IUnitOfWork.cs
	/// </summary>
	public interface IUnitOfWork
	{
		Task<int> SaveChangesAsync(CancellationToken ct = default);
		Task<bool> SaveEntitiesAsync(CancellationToken ct = default);
	}
}