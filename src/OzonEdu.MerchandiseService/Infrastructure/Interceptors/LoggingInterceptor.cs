using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Grpc.Core;
using Grpc.Core.Interceptors;

namespace OzonEdu.MerchandiseService.Infrastructure.Interceptors
{
	/// <summary>
	/// Interceptor для логирования запросов и ответов.
	/// </summary>
	public class LoggingInterceptor : Interceptor
	{
		private readonly ILogger _logger;

		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="logger"><see cref="ILogger"/>.</param>
		public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
		{
			_logger = logger;
		}

		/// <inheritdoc />
		public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
			TRequest request,
			ServerCallContext context,
			UnaryServerMethod<TRequest, TResponse> continuation)
		{
			var requestJson = JsonSerializer.Serialize(request);
			_logger.LogInformation("grpc request {Request}", requestJson);

			var response = await base.UnaryServerHandler(request, context, continuation);

			var responseJson = JsonSerializer.Serialize(response);
			_logger.LogInformation("grpc response {Response}", responseJson);

			return response;
		}
	}
}