﻿using Newtonsoft.Json;
using TaskManagiment_Application;
using TaskManagiment_Application.Common;
using TaskManagiment_Core.Exciption;

namespace TaskManagement_Api.Middleware
{
    public class ExceptionHandlerMiddlewear
    {

        private readonly ILogger<ExceptionHandlerMiddlewear> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddlewear(ILogger<ExceptionHandlerMiddlewear> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            _logger.LogError(ex.Message);

            var code = StatusCodes.Status500InternalServerError;
            var errors = new List<string> { ex.Message };

            if (ex.InnerException != null)
            {
                errors.Add(ex.InnerException.Message);
            }

            code = ex switch
            {
                DirectoryNotFoundException => StatusCodes.Status404NotFound,
                ResourceNotFound => StatusCodes.Status404NotFound,
                BadHttpRequestException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            var result = JsonConvert.SerializeObject(ApiResult<string>.Failure(new Error(code.ToString(), code.ToString())));

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            return context.Response.WriteAsync(result);
        }
    }
}
