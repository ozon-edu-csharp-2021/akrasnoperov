using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate
{
	/// <summary>
	/// Entity, описывающая тип MerchPack.
	/// </summary>
	public class MerchPack : Entity
	{
		/// <summary>
		/// <see cref="MerchAggregate.Name"/>.
		/// </summary>
		public Name Name { get; }

		/// <summary>
		/// .ctor
		/// </summary>
		public MerchPack(
			long id,
			Name name) : this(name)
		{
			Id = id;
		}

		/// <summary>
		/// .ctor
		/// </summary>
		public MerchPack(Name name)
		{
			Name = name;
		}
	}
}