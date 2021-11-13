namespace OzonEdu.MerchandiseService.HttpModels
{
	/// <summary>
	/// Ответ на запрос на выдачу мерча сотруднику.
	/// </summary>
	public class IssueMerchResponse
	{
		/// <summary>
		/// Статус выдачи мерча сотруднику.
		/// </summary>
		public int Status { get; set; }

		public IssueMerchResponse(int status)
		{
			Status = status;
		}
	}
}