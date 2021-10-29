using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OzonEdu.MerchandiseService.Infrastructure.Middlewares
{
	/// <summary>
	/// Терминальный middleware для возврата версии приложения.
	/// </summary>
	public class VersionMiddleware
	{
		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="next">Следующий <see cref="RequestDelegate"/>.</param>
		public VersionMiddleware(RequestDelegate next)
		{
		}

		/// <summary>
		/// Возвращает версию приложения в теле ответа.
		/// </summary>
		/// <param name="context"></param>
		public async Task InvokeAsync(HttpContext context)
		{
			context.Response.Clear();
			context.Response.StatusCode = StatusCodes.Status200OK;

			var version = Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? "no version";
			var serviceName = Assembly.GetEntryAssembly()?.GetName().Name ?? "no service name";
			var body = JsonSerializer.Serialize(new
			{
				version = version,
				serviceName = serviceName
			});

			await context.Response.WriteAsync(body);
		}
	}
}