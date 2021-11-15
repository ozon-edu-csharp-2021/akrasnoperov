using OzonEdu.MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate
{
	/// <summary>
	/// Entity, описывающая связь многие-ко-многим между
	/// <see cref="MerchPack"/> и <see cref="Merch"/>.
	/// </summary>
	public class MerchPackToMerch : Entity
	{
		/// <summary>
		/// <see cref="IssuedMerchAggregate.Quantity"/>
		/// </summary>
		public Quantity Quantity { get; }

		/// <summary>
		/// <see cref="MerchAggregate.Merch"/>.
		/// </summary>
		public Merch Merch { get; }

		/// <summary>
		/// <see cref="MerchAggregate.MerchPack"/>.
		/// </summary>
		public MerchPack MerchPack { get; }

		/// <summary>
		/// .ctor
		/// </summary>
		public MerchPackToMerch(
			Quantity quantity,
			Merch merch,
			MerchPack merchPack)
		{
			Quantity = quantity;
			Merch = merch;
			MerchPack = merchPack;
		}
	}
}