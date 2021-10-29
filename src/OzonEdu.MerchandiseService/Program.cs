using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using OzonEdu.MerchandiseService.Infrastructure.Extensions;

namespace OzonEdu.MerchandiseService
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		private static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					// Конфигурируем Kestrel, чтобы для HTTP API и для Grpc API использовались разные версии HTTP.
					webBuilder.ConfigureKestrel(options =>
					{
						options.ListenAnyIP(5000, listenOptions =>
						{
							listenOptions.Protocols = HttpProtocols.Http1;
						});

						options.ListenAnyIP(5004, listenOptions =>
						{
							listenOptions.Protocols = HttpProtocols.Http2;
						});
					});
					webBuilder.UseStartup<Startup>();
				})
				.AddInfrastructure();
	}
}
