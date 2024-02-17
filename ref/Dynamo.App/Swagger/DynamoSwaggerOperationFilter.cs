using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Dynamo.App.Swagger
{
    public class DynamoSwaggerOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();

            var parameters = new string[] { "lang" };

            var existingParams = operation.Parameters.Where(p =>
                p.In == ParameterLocation.Header && parameters.Contains(p.Name)).ToList();

            foreach (var param in existingParams)
            {
                operation.Parameters.Remove(param);
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "lang",
                In = ParameterLocation.Header,
                Description = "current language",
                Required = false,
                Content = new Dictionary<string, OpenApiMediaType>
                        {
                            {
                                "text/plain", new OpenApiMediaType
                                {
                                    Schema = new OpenApiSchema
                                    {
                                        Type = "string",
                                        Required = new HashSet<string>{ "string" },
                                        Properties = new Dictionary<string, OpenApiSchema>
                                        {
                                            {
                                                "string", new OpenApiSchema()
                                                {
                                                    Type = "string",
                                                    Format = "text"
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
            });
            
        }
    }

}
