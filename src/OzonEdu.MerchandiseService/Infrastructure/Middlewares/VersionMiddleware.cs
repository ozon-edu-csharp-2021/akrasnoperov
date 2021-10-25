using System.Reflection;
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
			var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "no version";
			context.Response.StatusCode = StatusCodes.Status200OK;
			await context.Response.WriteAsync(version);
		}
	}
}