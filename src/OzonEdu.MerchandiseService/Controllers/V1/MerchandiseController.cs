using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Infrastructure.Queries.EmployeeAggregate;

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
		private readonly IMediator _mediator;

		/// <summary>
		/// .ctor
		/// </summary>
		public MerchandiseController( IMediator mediator)
		{
			_mediator = mediator;
		}

		/// <summary>
		/// Запрашивает мерч по <paramref name="merchId"/>
		/// для выдачи сотруднику <paramref name="userId"/>.
		/// </summary>
		/// <param name="merchId">Идентификатор мерча.</param>
		/// <param name="userId">Идентификатор пользователя.</param>
		/// <param name="ct"><see cref="CancellationToken"/>.</param>
		[HttpPost("{merchId:int}/users/{userId:int}")]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public Task<IActionResult> IssueMerchAsync(
			[FromRoute] int merchId,
			[FromRoute] int userId,
			CancellationToken ct)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Возвращает информацию о выданном сотруднику мерче.
		/// </summary>
		/// <param name="employeeId">Идентификатор пользователя.</param>
		/// <param name="ct"><see cref="CancellationToken"/>.</param>
		/// <returns>Список <see cref="IssuedMerch"/></returns>
		[HttpGet("users/{employeeId:int}")]
		[ProducesResponseType(typeof(IssuedMerchResponse), 200)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> GetIssuedMerchAsync(
			[FromRoute] int employeeId,
			CancellationToken ct)
		{
			var query = new GetIssuedMerchQuery
			{
				EmployeeId = employeeId
			};
			var dict = await _mediator.Send(query, ct);

			var result = new IssuedMerchResponse(dict.Select(_ => new IssuedMerch(_.Key.Id, _.Value)).ToList());

			return Ok(result);
		}
	}
}