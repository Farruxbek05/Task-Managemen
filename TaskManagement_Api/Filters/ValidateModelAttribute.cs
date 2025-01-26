using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using TaskManagiment_Application;
using TaskManagiment_Application.Common;

namespace TaskManagement_Api.Filters
{
    public class ValidateModelAttribute : Attribute, IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values
                    .SelectMany(modelState => modelState.Errors)
                    .Select(modelError => Error.InternalServerError); // Convert to Error type

                context.Result = new BadRequestObjectResult(ApiResult<string>.Failure(errors.First())); // Use context.Result instead of context.ApiResult
            }

            await next();
        }
    }
}
