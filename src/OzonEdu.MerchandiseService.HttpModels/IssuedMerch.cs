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

	}
}