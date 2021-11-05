using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Queries.EmployeeAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.EmployeeAggregate
{
	/// <summary>
	/// Handler для Query <see cref="GetIssuedMerchQuery"/>.
	/// </summary>
	public class GetIssuedMerchQueryHandler : IRequestHandler<GetIssuedMerchQuery, IReadOnlyDictionary<Merch, DateTimeOffset>>
	{
		private readonly IEmployeeRepository _employeeRepository;

		/// <summary>
		/// .ctor
		/// </summary>\
		public GetIssuedMerchQueryHandler(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		/// <inheritdoc />
		public async Task<IReadOnlyDictionary<Merch, DateTimeOffset>> Handle(GetIssuedMerchQuery request, CancellationToken cancellationToken)
		{
			var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId, cancellationToken);

			return employee.GetIssuedMerches();
		}
	}
}