using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HW22.WebAPI.Services
{
	public class ExceptionFilter : IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			var responce = new
			{
				Exception = new
				{
					Message = "An error occurred while executing the request",
					Detail = context.Exception.Message
				}
			};

			context.Result = new JsonResult(responce)
			{
				StatusCode = (int)HttpStatusCode.InternalServerError
			};

			context.ExceptionHandled = true;
		}
	}
}
