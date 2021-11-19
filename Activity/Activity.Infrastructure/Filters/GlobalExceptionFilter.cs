using Activity.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(BusinessException))
            {
                var exception = (BusinessException)context.Exception;
                var arrayConten = exception.Message.Split(Core.Constant.General.Split);
                var validation = new
                {
                    Status = Convert.ToInt32(arrayConten[0]),
                    Title = arrayConten[1],
                    Detail = arrayConten[2]
                };
                var json = new
                {
                    error = new { validation }
                };
                context.Result = new ObjectResult(json)
                {
                    StatusCode = validation.Status,
                    DeclaredType = typeof(ProducesErrorResponseTypeAttribute)
                };
                context.HttpContext.Response.StatusCode = validation.Status;
                context.ExceptionHandled = true;
            }

        }
    }

}
