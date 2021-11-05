using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate
{
	/// <summary>
	/// Enumeration для статуса выдачи мерча сотруднику.
	/// </summary>
	public class Status : Enumeration
	{
		public static Status ReadyToIssue = new(1, "Мерч готов к выдаче");
		public static Status Issued = new(2, "Мерч выдан");
		public static Status Waiting = new(3, "Ожидается поступление мерча на склад для выдачи");

		/// <summary>
		/// .ctor
		/// </summary>
		private Status(int id, string name) : base(id, name)
		{
		}
	}
}