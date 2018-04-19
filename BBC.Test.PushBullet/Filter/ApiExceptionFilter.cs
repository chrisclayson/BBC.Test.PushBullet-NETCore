using System;
using BBC.Test.PushBullet.Exception;
using BBC.Test.PushBullet.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BBC.Test.PushBullet.Filter
{
    public class ApiExceptionFilter : Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute
    {
        public override void OnException(Microsoft.AspNetCore.Mvc.Filters.ExceptionContext context)
        {
            ApiError apiError = new ApiError();;

            if (context.Exception is ApiException)
            {
                ApiException ex = context.Exception as ApiException;

                apiError.Status = ex.StatusCode;
                context.HttpContext.Response.StatusCode = ex.StatusCode;
            }
            else
            {
                apiError = new ApiError();

                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            }
            apiError.TimeStamp = DateTime.UtcNow;
            apiError.Message = context.Exception.Message;
            apiError.ErrorPath = context.HttpContext.Request.Path.Value;
            context.ExceptionHandled = true;
            context.Result = new ObjectResult(apiError);

            base.OnException(context);
        }
    }
}
