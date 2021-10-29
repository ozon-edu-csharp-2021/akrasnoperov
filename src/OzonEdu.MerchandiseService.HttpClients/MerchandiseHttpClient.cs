using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClients
{
	/// <summary>
	/// TODO: Вынести интерфейс в отдельную сборку.
	/// Http-клиент для работы с мерчем.
	/// </summary>
	public interface IMerchandiseHttpClient
	{
		/// <summary>
		/// Запрашивает мерч по <paramref name="merchId"/>
		/// для выдачи сотруднику <paramref name="userId"/>.
		/// </summary>
		/// <param name="merchId">Идентификатор мерча.</param>
		/// <param name="userId">Идентификатор пользователя.</param>
		/// <param name="ct"><see cref="CancellationToken"/>.</param>
		Task IssueMerchAsync(
			int merchId,
			int userId,
			CancellationToken ct);

		/// <summary>
		/// Возвращает информацию о выданном сотруднику мерче.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя.</param>
		/// <param name="ct"><see cref="CancellationToken"/>.</param>
		/// <returns>Список <see cref="IssuedMerch"/></returns>
		Task<List<IssuedMerch>> GetIssuedMerchAsync(
			int userId,
			CancellationToken ct);
	}

	/// <inheritdoc />
	public class MerchandiseHttpClient : IMerchandiseHttpClient
	{
		private readonly HttpClient _httpClient;

		public MerchandiseHttpClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		/// <inheritdoc />
		public async Task IssueMerchAsync(
			int merchId,
			int userId,
			CancellationToken ct)
		{
			using var response = await _httpClient.PostAsync(
				$"v1/api/merch/{merchId}/users/{userId}",
				null!,
				ct);

			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public async Task<List<IssuedMerch>> GetIssuedMerchAsync(
			int userId,
			CancellationToken ct)
		{
			using var response = await _httpClient.GetAsync($"v1/api/merch/users/{userId}", ct);

			throw new NotImplementedException();
		}
	}
}