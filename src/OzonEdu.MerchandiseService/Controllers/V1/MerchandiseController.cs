using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Infrastructure.Commands.IssuedMerchAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Queries.IssuedMerchAggregate;

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
		/// Запрашивает мерч по <paramref name="sku"/>
		/// для выдачи сотруднику <paramref name="employeeId"/>.
		/// </summary>
		/// <param name="sku">Идентификатор товара на складе.</param>
		/// <param name="employeeId">Идентификатор пользователя.</param>
		/// <param name="quantity">Количество мерча для выдачи.</param>
		/// <param name="ct"><see cref="CancellationToken"/>.</param>
		[HttpPost("{sku:long}/users/{employeeId:int}")]
		[ProducesResponseType(typeof(IssueMerchResponse), 200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> IssueMerchAsync(
			[FromRoute] long sku,
			[FromRoute] int employeeId,
			[FromQuery] int quantity,
			CancellationToken ct)
		{
			var command = new IssueMerchCommand
			{
				Sku = sku,
				EmployeeId = employeeId,
				Quantity = quantity
			};

			var issuedMerch = await _mediator.Send(command, ct);
			var response = new IssueMerchResponse(issuedMerch.Status.Id);
			return Ok(response);
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
			[FromRoute] long employeeId,
			CancellationToken ct)
		{
			var query = new GetIssuedMerchQuery
			{
				EmployeeId = employeeId
			};
			var issuedMerches = await _mediator.Send(query, ct);

			var result = new IssuedMerchResponse(issuedMerches
				.Select(_ => new IssuedMerch(_.Merch.Id, _.Quantity.Value, _.IssueDate)).ToList());

			return Ok(result);
		}
	}
}