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
					webBuilder.UseStartup<Startup>();
					// Если при вызове Grpc получаете ошибку '14 UNAVAILABLE: Trying to connect an http1.x server',
					// то раскомментируйте строчку ниже.
					// webBuilder.ConfigureKestrel(kestrel => kestrel.ConfigureEndpointDefaults(options => options.Protocols = HttpProtocols.Http2));
				})
				.AddInfrastructure();
	}
}
