using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace OzonEdu.MerchandiseService.Infrastructure.StartupFilters
{
	/// <summary>
	/// IStartupFilter для подключения и конфигурирования Swagger.
	/// </summary>
	public class SwaggerStartupFilter : IStartupFilter
	{
		/// <inheritdoc />
		public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
		{
			return app =>
			{
				app.UseSwagger();
				app.UseSwaggerUI();
				next(app);
			};
		}
	}
}