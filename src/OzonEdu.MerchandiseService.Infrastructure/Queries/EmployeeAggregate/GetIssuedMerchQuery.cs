using System;
using System.Collections.Generic;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Queries.EmployeeAggregate
{
	/// <summary>
	/// Query для получения выданного сотруднику мерча.
	/// </summary>
	public class GetIssuedMerchQuery : IRequest<IReadOnlyDictionary<Merch, DateTimeOffset>>
	{
		public int EmployeeId { get; set; }
	}
}