using System;
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
		/// <see cref="MerchAggregate.Quantity"/>.
		/// </summary>
		public Quantity Quantity { get; set; }

		/// <summary>
		/// .ctor
		/// </summary>
		public Merch(
			Sku sku,
			Name name,
			MerchType merchType,
			Quantity quantity,
			ClothingSize? clothingSize = null)
		{
			// TODO: Просто заглушка. Убрать, когда подключим БД.
			Id = new Random().Next(1, 10_000);
			Sku = sku;
			Name = name;
			MerchType = merchType;
			Quantity = quantity;
			ClothingSize = clothingSize;
		}
	}
}