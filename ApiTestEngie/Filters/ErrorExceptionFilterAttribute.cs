using ApiTestEngie.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace ApiTestEngie.Filters
{
    /// <summary>
    /// Fxception handling with a filter 
    /// </summary>
    public class ErrorExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is NotImplementedException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
                Logger.GetLogger().WriteMessage(context.Request.RequestUri.OriginalString, context.Exception.Message);
            }
            else if(context.Exception is ArgumentNullException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                Logger.GetLogger().WriteMessage(context.Request.RequestUri.OriginalString, context.Exception.Message);
            }
            else if(context.Exception is NullReferenceException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                Logger.GetLogger().WriteMessage(context.Request.RequestUri.OriginalString, context.Exception.Message);
            }
        }
    }
}