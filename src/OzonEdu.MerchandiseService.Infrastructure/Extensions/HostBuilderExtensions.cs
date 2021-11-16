using System;
using System.IO;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OzonEdu.MerchandiseService.Infrastructure.Commands.IssuedMerchAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Filters;
using OzonEdu.MerchandiseService.Infrastructure.Handlers.IssuedMerchAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Interceptors;
using OzonEdu.MerchandiseService.Infrastructure.PipelineBehaviors;
using OzonEdu.MerchandiseService.Infrastructure.StartupFilters;

namespace OzonEdu.MerchandiseService.Infrastructure.Extensions
{
	/// <summary>
	/// Класс с расширениями для IHostBuilder.
	/// </summary>
	public static class HostBuilderExtensions
	{
		/// <summary>
		/// Добавляет инфраструктуру в проект.
		/// </summary>
		/// <param name="builder"><see cref="IHostBuilder"/>.</param>
		/// <returns><see cref="IHostBuilder"/>.</returns>
		public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
		{
			builder.ConfigureServices(services =>
			{
				services.AddSingleton<IStartupFilter, ServiceInfoStartupFilter>();

				services.AddSingleton<IStartupFilter, SwaggerStartupFilter>()
					.AddSwaggerGen(options =>
					{
						options.CustomSchemaIds(x => x.FullName);

						var xmlFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
						var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
						options.IncludeXmlComments(xmlFilePath);
					});

				services.AddSingleton<IStartupFilter, LoggingStartupFilter>();

				services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());

				services.AddValidatorsFromAssembly(typeof(IssueMerchCommandValidator).Assembly);

				services.AddMediatR(typeof(GetIssuedMerchQueryHandler).Assembly)
					.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

				services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());
			});

			return builder;
		}
	}
}