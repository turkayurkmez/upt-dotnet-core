using System.Text;

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
                //using var streamReader = new StreamReader(context.Request.Body);
                //var jsonBody = await streamReader.ReadToEndAsync();
                var requestBody = new StreamReader(context.Request.BodyReader.AsStream()).ReadToEnd();
                var content = Encoding.UTF8.GetBytes(requestBody);
                var requestBodyStream = new MemoryStream();
                requestBodyStream.Seek(0, SeekOrigin.Begin);
                requestBodyStream.Write(content, 0, content.Length);
                context.Request.Body = requestBodyStream;
                context.Request.Body.Seek(0, SeekOrigin.Begin);
                context.Items["jsonBody"] = requestBody;
            }

            await _next(context);
        }
    }
}
