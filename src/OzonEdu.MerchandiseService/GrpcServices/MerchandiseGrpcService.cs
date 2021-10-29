using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using OzonEdu.MerchandiseService.Grpc;

namespace OzonEdu.MerchandiseService.GrpcServices
{
	/// <summary>
	/// Grpc-сервис для работы с мерчем.
	/// </summary>
	public class MerchandiseGrpcService : OzonEdu.MerchandiseService.Grpc.MerchandiseGrpcService.MerchandiseGrpcServiceBase
	{
		/// <summary>
		/// Запрашивает мерч для выдачи сотруднику.
		/// </summary>
		/// <param name="request"><see cref="IssueMerchRequest"/>.</param>
		/// <param name="context"><see cref="ServerCallContext"/>.</param>
		public override Task<Empty> IssueMerchAsync(
			IssueMerchRequest request,
			ServerCallContext context)
		{
			return base.IssueMerchAsync(request, context);
		}

		/// <summary>
		/// Возвращает информацию о выданном сотруднику мерче.
		/// </summary>
		/// <param name="request"><see cref="GetIssuedMerchRequest"/>.</param>
		/// <param name="context"><see cref="ServerCallContext"/>.</param>
		/// <returns><see cref="GetIssuedMerchResponse"/>.</returns>
		public override Task<GetIssuedMerchResponse> GetIssuedMerchAsync(
			GetIssuedMerchRequest request,
			ServerCallContext context)
		{
			return base.GetIssuedMerchAsync(request, context);
		}
	}
}