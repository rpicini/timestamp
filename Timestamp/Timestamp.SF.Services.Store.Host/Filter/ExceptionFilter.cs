using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Timestamp.Core.Exceptions;
using Timestamp.Core.Response;

namespace Timestamp.Api.Filter
{
    public class ExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;
        private Stopwatch stopwatch;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is FieldsValidationException fException)
            {
                context.Result = new ObjectResult(fException.Status)
                {
                    StatusCode = fException.Status,
                    Value = new Response<dynamic>
                    {
                        Status = "Bad Request",
                        Message = fException.Message,
                        Duration = stopwatch.Elapsed.TotalMinutes,
                    }
                };
                context.ExceptionHandled = true;
            }
            else if (context.Exception is Exception exception)
            {
                stopwatch.Stop();

                context.Result = new ObjectResult(exception.Message)
                {
                    StatusCode = 500,
                    Value = new Response<dynamic>
                    {
                        Status = "500 Internal Server Error",
                        Message = "Ops! An unexpected error occurred while processing the request. Contact the administrator.",
                        Duration = stopwatch.Elapsed.TotalMinutes,
                    }
                };
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }
    }
}
