using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.IssuedMerchAggregate
{
	/// <summary>
	/// Command для выдачи мерча сотруднику.
	/// </summary>
	public class IssueMerchCommand : IRequest<IssuedMerch>
	{
		/// <summary>
		/// Идентификатор сотрудника.
		/// </summary>
		public int EmployeeId { get; set; }

		/// <summary>
		/// SKU.
		/// </summary>
		public long Sku { get; set; }

		/// <summary>
		/// Количество мерча для выдачи.
		/// </summary>
		public int Quantity { get; set; }
	}
}