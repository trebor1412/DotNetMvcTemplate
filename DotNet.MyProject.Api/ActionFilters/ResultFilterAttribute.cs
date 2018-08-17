using DotNet.Core;
using System.Net.Http;
using System.Web.Http.Filters;

namespace DotNet.MyProject.Api
{
    public class ResultFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                return;
            }

            var objectContent = actionExecutedContext.Response.Content as ObjectContent;
            var result = new Result<object>
            {
                IsSuccess = true,
                Data = objectContent?.Value
            };

            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(result);
        }
    }
}