using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eshop.API.Filters
{
    public class RangeExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentOutOfRangeException)
            {
                var arg = (ArgumentOutOfRangeException)context.Exception;
                string message = $"{context.ActionDescriptor.DisplayName} adresine gönderdiğiniz http request'inde {arg.ParamName} parametresi aralığın dışında.. ";

                context.Result = new BadRequestObjectResult(message);

            }
        }
    }
}
