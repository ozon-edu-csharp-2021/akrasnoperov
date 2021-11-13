using System.Collections.Generic;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Queries.IssuedMerchAggregate
{
	/// <summary>
	/// Query для получения выданного сотруднику мерча.
	/// </summary>
	public class GetIssuedMerchQuery : IRequest<IReadOnlyCollection<IssuedMerch>>
	{
		/// <summary>
		/// Идентификатор сотрудника.
		/// </summary>
		public long EmployeeId { get; set; }
	}
}