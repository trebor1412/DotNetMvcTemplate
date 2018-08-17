using DotNet.Core;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace DotNet.MyProject.Api
{
    public class ExceptionHandleFilterAttributte : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                //Log Exception
                //ErrorSignal.FromCurrentContext().Raise(actionExecutedContext.Exception);
            }

            actionExecutedContext.Response =
                actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError,
                new Result<string> { Message = actionExecutedContext.Exception.Message });
        }
    }
}