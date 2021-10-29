using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using OzonEdu.MerchandiseService.Infrastructure.Middlewares;

namespace OzonEdu.MerchandiseService.Infrastructure.StartupFilters
{
	/// <summary>
	/// IStartupFilter для подключения и конфигурирования логирования.
	/// </summary>
	public class LoggingStartupFilter : IStartupFilter
	{
		/// <inheritdoc />
		public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
		{
			return app =>
			{
				app.UseMiddleware<HttpLoggingMiddleware>();
				next(app);
			};
		}
	}
}