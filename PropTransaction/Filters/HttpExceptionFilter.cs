using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropTransaction.Model;
using Serilog;

// https://docs.microsoft.com/en-us/aspnet/core/web-api/handle-errors?view=aspnetcore-5.0

namespace PropTransaction.Filters
{
    // After excecute controller, handle post exception handling if any
    public abstract class ExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public abstract void OnException(ExceptionContext context);
    }

    public class HttpExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Log.Error(context.Exception.Message);

            //// possibly handdle the exception here!
            //{
            //    context.ExceptionHandled = true;
            //}
            throw context.Exception;
        }

        //public override void OnException(ExceptionContext context)
        //{
        //    if (context.Exception is HttpResponseException exception)
        //    {
        //        context.Result = new ObjectResult(exception.Value)
        //        {
        //            StatusCode = exception.Status,
        //        };
        //        context.ExceptionHandled = true;
        //    }
        //}
    }
}
