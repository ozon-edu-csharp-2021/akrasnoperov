using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.Controllers.V1
{
	/// <summary>
	/// Контроллер для работы с мерчем.
	/// </summary>
	[ApiController]
	[Route("v1/api/merch")]
	[Produces("application/json")]
	public class MerchandiseController : ControllerBase
	{
		/// <summary>
		/// Запрашивает мерч по <paramref name="merchId"/>
		/// для выдачи сотруднику <paramref name="userId"/>.
		/// </summary>
		/// <param name="merchId">Идентификатор мерча.</param>
		/// <param name="userId">Идентификатор пользователя.</param>
		/// <param name="token"><see cref="CancellationToken"/>.</param>
		[HttpPost("{merchId:int}/users/{userId:int}")]
		[ProducesResponseType(204)]
		[ProducesResponseType(404)]
		[ProducesResponseType(404)]
		public Task<IActionResult> IssueMerchAsync(
			[FromRoute] int merchId,
			[FromRoute] int userId,
			CancellationToken token)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Возвращает информацию о выданном сотруднику мерче.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя.</param>
		/// <param name="token"><see cref="CancellationToken"/>.</param>
		/// <returns>Список <see cref="IssuedMerch"/></returns>
		[HttpGet("users/{userId:int}")]
		[ProducesResponseType(typeof(IssuedMerchResponse), 200)]
		[ProducesResponseType(404)]
		public Task<IActionResult> GetIssuedMerchAsync(
			[FromRoute] int userId,
			CancellationToken token)
		{
			throw new NotImplementedException();
		}
	}
}