using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate
{
	/// <summary>
	/// Enumeration для типа Merch.
	/// </summary>
	public class MerchType : Enumeration
	{
		public static MerchType TShirt = new(1, nameof(TShirt));
		public static MerchType Sweatshirt = new(2, nameof(Sweatshirt));
		public static MerchType Notepad = new(3, nameof(Notepad));
		public static MerchType Bag = new(4, nameof(Bag));
		public static MerchType Pen = new(5, nameof(Pen));
		public static MerchType Socks = new(6, nameof(Socks));

		/// <summary>
		/// .ctor
		/// </summary>
		public MerchType(int id, string name) : base(id, name)
		{
		}
	}
}