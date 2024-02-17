using System.IO;
using System.Text;
using Dynamo.Core.Entities.Base;
using Dynamo.Core.Other;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Newtonsoft.Json;

namespace Dynamo.App.Middlewares
{
    public class DynamoLoggerMiddleware
    {
        private readonly RequestDelegate next;

        public DynamoLoggerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, DynamoSession dynamoSession)
        {
            try
            {
                await next(context);
            }
            catch (Exception error)
            {

                //get controller
                var controllerActionDescriptor = context?
                    .GetEndpoint()?
                    .Metadata
                    .GetMetadata<ControllerActionDescriptor>();

                var controllerName = controllerActionDescriptor?.ControllerName;
                var actionName = controllerActionDescriptor?.ActionName;

                var request = context?.Request;
                var queryString = request?.QueryString.Value;

                string body;
                if (request != null)
                {
                    request.EnableBuffering();
                    request.Body.Seek(0, SeekOrigin.Begin);
                    request.Body.Position = 0;
                    using StreamReader reader = new(request.Body, Encoding.UTF8, true, 1024, true);
                    body = await reader.ReadToEndAsync();
                }

                // **** should log error here
                // Create a string array with the lines of text
                string[] lines = { "Date: " + DateTime.Now.ToString()
                        , "UserId :" + dynamoSession.UserId
                        , "UserName :" + dynamoSession.UserName
                        , "Error :" + error.Message
                        , "InnerError: " + error.InnerException?.Message
                        , "ControllerName: " + controllerName
                        , "ActionName: " + actionName
                        , "Request: " + request
                        , "QueryString: " + queryString
                        , "Stack: " + error.StackTrace
                        , "\n"
                        };

                // get file name for date of today.
                var fileName = DateTime.Now.Year.ToString()
                    + (DateTime.Now.Month.ToString().Length<2?"0"+ DateTime.Now.Month.ToString(): DateTime.Now.Month.ToString())
                    + (DateTime.Now.Day.ToString().Length < 2 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString());

                string logPath = @"C:\Logs\";
                string filePath = logPath + @"\" + fileName;

                if (!Directory.Exists(logPath))
                    Directory.CreateDirectory(logPath);

                if (!File.Exists(filePath))
                {
                    var file = File.Create(filePath);
                    file.Close();
                }

                File.AppendAllLines(filePath, lines);
                // **** 

                switch (error)
                {
                    case DynamoException e:
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = 400;
                        var response = new ApiResponse(400, e.Message);
                        var json = JsonConvert.SerializeObject(response);
                        await context.Response.WriteAsync(json);
                        break;
                    default:
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = 500;
                        response = new ApiResponse(500);
                        json = JsonConvert.SerializeObject(response);
                        await context.Response.WriteAsync(json);
                        break;
                }

                //throw error switch
                //{
                //    DynamoException e => new BadHttpRequestException("*_*" + e.ErrorMessage + "*_*"),
                //    _ => new BadHttpRequestException("*_*" + error.Message + "*_*")
                //};
            }
        }
    }

    public class ApiResponse
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
            case 400:
                return "Bad request";
            case 500:
                return "An unhandled error occurred";
            default:
                return null;
        }
    }
}
}
