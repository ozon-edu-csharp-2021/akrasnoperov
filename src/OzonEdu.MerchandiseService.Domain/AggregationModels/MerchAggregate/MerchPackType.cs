using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate
{
	/// <summary>
	/// Enumeration для типа MerchPack.
	/// </summary>
	public class MerchPackType : Enumeration
	{
		public static MerchPackType Welcome = new(1, "Пак для нового сотрудника");
		public static MerchPackType Starter = new(2, "Пак для прошедшего испытатльный срок сотрудника");
		public static MerchPackType ConferenceListener = new(3, "Пак для сотрудника, участвующего в конференции в качестве слушателя");
		public static MerchPackType ConferenceSpeaker = new(4, "Пак для сотрудника, участвующего в конференции в качестве докладчика");
		public static MerchPackType Veteran = new(5, "Пак для отработавшего больше 5 лет сотрудника");

		/// <summary>
		/// .ctor
		/// </summary>
		private MerchPackType(int id, string name) : base(id, name)
		{
		}
	}
}