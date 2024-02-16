using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP.NET.Auth
{
    public class ExceptionHandler : ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string message = "Произошла непредвиденная ошибка. Администрация сайта уже бежит, волосы назад!";

            if (context.Exception is CustomException)
                message = context.Exception.Message;

            context.Result = new BadRequestObjectResult(message);
        }
    }
}
