﻿using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Serilog;

namespace BlaccEnterprise.Interview.Api.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _request;
        private static readonly ILogger _logger = Log.ForContext<GlobalExceptionMiddleware>();

        public GlobalExceptionMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _request(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            _logger.Error($"{DateTime.Now.ToString("HH:mm:ss")} : {ex}");

            return Task.CompletedTask;
        }
    }
}
