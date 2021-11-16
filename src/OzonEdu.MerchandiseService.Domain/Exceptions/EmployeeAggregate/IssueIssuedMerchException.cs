using System;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate;

namespace OzonEdu.MerchandiseService.Domain.Exceptions.EmployeeAggregate
{
	/// <summary>
	/// Исключение для ситуаций, когда пытаемся выдать мерч сотруднику, которому он уже был выдан ранее,
	/// и с момента выдачи прошло меньше года.
	/// </summary>
	public class IssueIssuedMerchException : Exception
	{
		/// <summary>
		/// .ctor
		/// </summary>
		public IssueIssuedMerchException(MerchType merchType) : base($"С момента выдачи мерча типа {merchType} прошло меньше года.")
		{
		}
	}
}