using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;
using OzonEdu.MerchandiseService.GrpcServices;
using OzonEdu.MerchandiseService.Infrastructure.Stubs;

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
			services.AddTransient<IIssuedMerchRepository, IssuedMerchRepository>();
			services.AddTransient<IEmployeeRepository, EmployeeRepository>();
			services.AddTransient<IMerchRepository, MerchRepository>();
			services.AddTransient<IUnitOfWork, UnitOfWork>();
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
				endpoints.MapGrpcService<MerchandiseGrpcService>();
				endpoints.MapControllers();
			});
		}
	}
}
