using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Queries.IssuedMerchAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.IssuedMerchAggregate
{
	/// <summary>
	/// Handler для Query <see cref="GetIssuedMerchQuery"/>.
	/// </summary>
	public class GetIssuedMerchQueryHandler : IRequestHandler<GetIssuedMerchQuery, IReadOnlyCollection<IssuedMerch>>
	{
		private readonly IIssuedMerchRepository _issuedMerchRepository;

		/// <summary>
		/// .ctor
		/// </summary>\
		public GetIssuedMerchQueryHandler(IIssuedMerchRepository issuedMerchRepository)
		{
			_issuedMerchRepository = issuedMerchRepository;
		}

		/// <inheritdoc />
		public async Task<IReadOnlyCollection<IssuedMerch>> Handle(GetIssuedMerchQuery request, CancellationToken cancellationToken)
		{
			return await _issuedMerchRepository.GetIssuedMerches(request.EmployeeId, cancellationToken);
		}
	}
}