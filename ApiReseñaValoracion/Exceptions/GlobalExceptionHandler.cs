using BadRequestException = ApiReseñaValoracion.Exceptions.BadRequestException;
using KeynotFoundException = ApiReseñaValoracion.Exceptions.KeyNotFoundException;
using NotFoundException = ApiReseñaValoracion.Exceptions.NotFoundException;
using UnauthorizedException = ApiReseñaValoracion.Exceptions.UnauthorizedException;
using System.Net;
using System.Text.Json;
namespace ApiCustomer.Exceptions
{
	public class GlobalExceptionHandler
	{
		private readonly RequestDelegate _next;
		public GlobalExceptionHandler(RequestDelegate _next)
		{
			this._next = _next;

		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);

			}
		}

		private static Task HandleExceptionAsync(HttpContext context,Exception ex)
		{
			HttpStatusCode statusCode;
			DateTime timeStamp = DateTime.Now;
			string? stackTrace;
			string message;

			var exType = ex.GetType();
			if (exType == typeof(BadRequestException))
			{
				statusCode = HttpStatusCode.BadRequest;
			}
			else if (exType == typeof(UnauthorizedException))
			{
				statusCode = HttpStatusCode.Unauthorized;
			}
			else if (exType == typeof(KeynotFoundException))
			{
				statusCode = HttpStatusCode.Unauthorized;
			}
			else if (exType == typeof(NotFoundException))
			{
				statusCode = HttpStatusCode.NotFound;
			}
			else
			{
				statusCode = HttpStatusCode.InternalServerError;
			}
			message = ex.Message;
			stackTrace = ex.StackTrace;
			var exceptionResult = JsonSerializer.Serialize(new
			{
				error=timeStamp,message,stackTrace,
			} );
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)statusCode;
			return context.Response.WriteAsync(exceptionResult);

		}
	}
}

