namespace customMiddlewares.Middlewares
{
    public class JsonBodyMiddleware
    {
        /*
         * Eğer bir http request nesnesi POST metodu ile çalışmış ve bu request'de JSON bir veri varsa daha sonra işlemek üzere bu veriyi ayır!
         */
        private readonly RequestDelegate _next;

        public JsonBodyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            if (context.Request.Method == "POST" && context.Request.ContentType.StartsWith("application/json"))
            {
                using var streamReader = new StreamReader(context.Request.Body);
                var jsonBody = await streamReader.ReadToEndAsync();
                context.Items["jsonBody"] = jsonBody;
            }
            context.Request.Body.Seek(0, SeekOrigin.Begin);
            await _next(context);
        }
    }
}
