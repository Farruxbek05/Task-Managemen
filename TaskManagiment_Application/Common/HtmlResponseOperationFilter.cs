using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TaskManagiment_Application.Common
{
    public class HtmlResponseOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Agar API javobi HTML formatda bo'lsa
            operation.Responses["200"] = new OpenApiResponse
            {
                Description = "HTML Response",
                Content = new Dictionary<string, OpenApiMediaType>
                {
                    ["text/html"] = new OpenApiMediaType()
                }
            };
        }
    }
}
