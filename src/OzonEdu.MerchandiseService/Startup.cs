using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace OzonEdu.MerchandiseService
{
	/// <summary>
	/// Startup-класс.
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// This method gets called by the runtime. Use this method to add services to the container.
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/>.</param>
		public void ConfigureServices(IServiceCollection services)
		{
		}

		/// <summary>
		/// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// </summary>
		/// <param name="app"><see cref="IApplicationBuilder"/>.</param>
		/// <param name="env"><see cref="IWebHostEnvironment"/>.</param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
