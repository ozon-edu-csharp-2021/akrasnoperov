using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate
{
	/// <summary>
	/// Entity, описывающая Merch.
	/// </summary>
	public class Merch : Entity
	{
		/// <summary>
		/// <see cref="MerchAggregate.Sku"/>.
		/// </summary>
		public Sku Sku { get; }

		/// <summary>
		/// <see cref="MerchAggregate.Name"/>.
		/// </summary>
		public Name Name { get; }

		/// <summary>
		/// <see cref="MerchAggregate.MerchType"/>.
		/// </summary>
		public MerchType MerchType { get; }

		/// <summary>
		/// <see cref="MerchAggregate.ClothingSize"/>.
		/// </summary>
		public ClothingSize? ClothingSize { get; }

		/// <summary>
		/// Список выданного мерча сотруднику <see cref="IssuedMerch"/>.
		/// </summary>
		public ICollection<IssuedMerch> IssuedMerches { get; set; }

		/// <summary>
		/// .ctor
		/// </summary>
		public Merch(
			long id,
			Sku sku,
			Name name,
			MerchType merchType,
			ClothingSize? clothingSize = null) : this(sku, name, merchType, clothingSize)
		{
			Id = id;
		}

		/// <summary>
		/// .ctor
		/// </summary>
		public Merch(
			Sku sku,
			Name name,
			MerchType merchType,
			ClothingSize? clothingSize = null)
		{
			Sku = sku;
			Name = name;
			MerchType = merchType;
			ClothingSize = clothingSize;
			IssuedMerches = new HashSet<IssuedMerch>();
		}
	}
}