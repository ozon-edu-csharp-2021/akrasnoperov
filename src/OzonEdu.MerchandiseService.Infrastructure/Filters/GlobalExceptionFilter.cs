using System.Collections.Generic;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.Domain.Exceptions.EmployeeAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Exceptions;

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
				StackTrace = context.Exception.StackTrace,
				Message = context.Exception.Message,
				Errors = new Dictionary<string, string>()
			};

			int statusCode;
			switch (context.Exception)
			{
				case IssueIssuedMerchException or WrongClothingSizeException or InvalidValueObjectException:
					statusCode = StatusCodes.Status400BadRequest;
					break;
				case ValidationException ex:
					statusCode = StatusCodes.Status400BadRequest;
					foreach (var error in ex.Errors)
					{
						resultObject.Errors.Add(error.PropertyName, error.ErrorMessage);
					}
					break;
				case EntityNotFoundException:
					statusCode = StatusCodes.Status404NotFound;
					break;
				default:
					statusCode = StatusCodes.Status500InternalServerError;
					break;
			}

			var jsonResult = new JsonResult(resultObject)
			{
				StatusCode = statusCode
			};
			context.Result = jsonResult;
		}
	}
}