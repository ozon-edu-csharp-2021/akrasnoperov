using System;
using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.HttpModels
{
	/// <summary>
	/// Ответ на запрос выданного мерча сотруднику.
	/// </summary>
	public class IssuedMerchResponse
	{
		/// <summary>
		/// Список <see cref="IssuedMerch"/>.
		/// </summary>
		public IReadOnlyCollection<IssuedMerch> IssuedMerches { get; }

		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="issuedMerches">Список <see cref="IssuedMerch"/>.</param>
		public IssuedMerchResponse(IReadOnlyCollection<IssuedMerch> issuedMerches)
		{
			IssuedMerches = issuedMerches;
		}
	}

	/// <summary>
	/// Модель для выданного мерча сотруднику.
	/// </summary>
	public class IssuedMerch
	{
		/// <summary>
		/// Идентификатор выданного мерча.
		/// </summary>
		public long MerchId { get; }

		/// <summary>
		/// Количество выданного мерча.
		/// </summary>
		public int Quantity { get; }

		/// <summary>
		/// Дата выдачи мерча.
		/// </summary>
		public DateTimeOffset IssuedDate { get; }

		public IssuedMerch(
			long merchId,
			int quantity,
			DateTimeOffset issuedDate)
		{
			MerchId = merchId;
			Quantity = quantity;
			IssuedDate = issuedDate;
		}
	}
}