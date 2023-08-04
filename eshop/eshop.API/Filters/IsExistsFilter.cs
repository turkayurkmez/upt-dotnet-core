using eshop.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eshop.API.Filters
{
    public class IsExistsFilter : IAsyncActionFilter
    {
        private readonly IProductService productService;

        public IsExistsFilter(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //1. action argümanı id parametresi içeriyor mu?
            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new BadRequestObjectResult(new { message = $"{context.ActionDescriptor.DisplayName} action'u id parametresi içermiyor!" });
                return;
            }
            //2. id int mi?
            if (!(context.ActionArguments["id"] is int id))
            {
                context.Result = new BadRequestObjectResult(new { message = $"{context.ActionDescriptor.DisplayName} action'u id parametresi sayı olmalı!" });
                return;
            }

            //3. o id'de ürün var mı?
            if (!(await productService.IsProductExists(id)))
            {
                context.Result = new NotFoundObjectResult(new { message = $"{id} id'li ürün yok." });
                return;
            }

            await next();
        }
    }
}
