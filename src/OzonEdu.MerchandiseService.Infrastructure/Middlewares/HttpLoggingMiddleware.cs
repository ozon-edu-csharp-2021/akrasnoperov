using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace OzonEdu.MerchandiseService.Infrastructure.Middlewares
{
	/// <summary>
	/// Middleware для логирования запросов (Route, Headers, Body)
	/// и ответов (Http status code, Route, Headers, Body)
	/// исключая Grpc-запросы.
	/// </summary>
	public class HttpLoggingMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger _logger;

		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="next">Следующий <see cref="RequestDelegate"/>.</param>
		/// <param name="logger"><see cref="ILogger"/>.</param>
		public HttpLoggingMiddleware(
			RequestDelegate next,
			ILogger<HttpLoggingMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		/// <summary>
		/// Логирует запрос и ответ.
		/// </summary>
		/// <param name="context"></param>
		public async Task InvokeAsync(HttpContext context)
		{
			await LogRequestAsync(context);
			await _next(context);
			await LogResponse(context);
		}

		private Task LogRequestAsync(HttpContext context)
		{
			try
			{
				if (!IsGrpc(context))
				{
					_logger.LogInformation(
						"Request {HttpMethod} {Route}, with headers {Headers}",
						GetHttpMethod(context),
						GetRoute(context),
						GetHeaders(context.Request?.Headers));
				}
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Could not log request");
			}

			return Task.CompletedTask;
		}

		private Task LogResponse(HttpContext context)
		{
			try
			{
				if (!IsGrpc(context))
				{
					var httpStatusCode = context.Response?.StatusCode;

					_logger.LogInformation(
						"{HttpMethod} {Route} responsed {HttpStatusCode}, with headers {Headers}",
						GetHttpMethod(context),
						GetRoute(context),
						httpStatusCode,
						GetHeaders(context.Response?.Headers));
				}
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Could not log response");
			}

			return Task.CompletedTask;
		}

		private static string GetHttpMethod(HttpContext context)
		{
			return context.Request?.Method?.ToUpperInvariant() ?? "unknown http method";
		}

		private static string GetRoute(HttpContext context)
		{
			return context.Request?.Path.Value ?? "unknown route";
		}

		private static IReadOnlyCollection<string> GetHeaders(IHeaderDictionary? headers)
		{
			return headers == null
				? new List<string>()
				: headers.Select(_ => $"{_.Key}: {_.Value}").ToList();
		}

		private static bool IsGrpc(HttpContext context)
		{
			return context.Request?.Headers?
				.Any(_ => _.Key == "Content-Type" && _.Value == "application/grpc") ?? false;
		}
	}
}