using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OzonEdu.MerchandiseService.Infrastructure.Filters
{
	/// <summary>
	/// Глобальный фильтр для обработки всех ранее не обработанных исключений.
	/// </summary>
	public class GlobalExceptionFilter : ExceptionFilterAttribute
	{
		/// <inheritdoc />
		public override void OnException(ExceptionContext context)
		{
			var resultObject = new
			{
				ExceptionType = context.Exception.GetType().FullName,
				StackTrace = context.Exception.StackTrace
			};

			var jsonResult = new JsonResult(resultObject)
			{
				StatusCode = StatusCodes.Status500InternalServerError
			};
			context.Result = jsonResult;
		}
	}
}