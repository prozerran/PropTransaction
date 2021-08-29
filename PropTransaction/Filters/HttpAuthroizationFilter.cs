﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropTransaction.Model;

// https://docs.microsoft.com/en-us/aspnet/core/web-api/handle-errors?view=aspnetcore-5.0

namespace PropTransaction.Filters
{
    // Pre method calls, handles any authorization before hand
    public abstract class AuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        public abstract void OnAuthorization(AuthorizationFilterContext context);
    }

    public class HttpAuthroizationFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(AuthorizationFilterContext context)
        {
            var sessionId = context.HttpContext.Request.Headers["Authorization"];
        }
    }
}
