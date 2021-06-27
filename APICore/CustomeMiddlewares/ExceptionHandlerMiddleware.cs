using APICore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace APICore.CustomeMiddlewares
{

    public class ExceptionInfo
    {
        public int ExceptionStatusCode { get; set; }
        public string ExceptionMessage { get; set; }
    }


    public class ExceptionHandlerMiddleware
    {

        private readonly RequestDelegate _next;
		private readonly ExceptionHistory _exc;

		public ExceptionHandlerMiddleware(RequestDelegate next, ExceptionHistory exc)
        {
            _next = next;
			_exc = exc;

		}


		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				// if no error then continue with next middlewares in pipeline
				await _next(context);
			}
			catch (Exception ex)
			{
				// if exception occures then catch it and generate response
				context.Response.StatusCode = 500;

				var exceptionDetails = new ExceptionInfo()
				{
					ExceptionStatusCode = context.Response.StatusCode,
					ExceptionMessage = ex.Message


				};

				var exceptionDetails1 = new ExceptionHistory()
				{
					//var controllername = @ViewContext.RouteData.Values["controller"].ToString()
					//LogGuid = context.Response.StatusCode,
					//RequestTime = DateTime.Now,
					//ControllerName=,
					//ActionMethod=,
					//ExceptionHandled=


				};

				// serialize the Object so that it can be written into the response
				string responseMessage = JsonSerializer.Serialize(exceptionDetails);

				// write the response
				await context.Response.WriteAsync(responseMessage);
			}
		}

		
	}

	public static class CustomMiddlewareExtensions
	{
		public static void UseExceptionMiddleware(this IApplicationBuilder app)
		{
			app.UseMiddleware<ExceptionHandlerMiddleware>();
		}
	}

}
