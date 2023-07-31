namespace customMiddlewares.Middlewares
{
    public class BadWordsHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public BadWordsHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var jsonBody = (string?)context.Items["jsonBody"];
            var badwords = new List<string> { "pis", "kaka", "kötü", "deli" };
            if (jsonBody != null && badwords.Any(word => jsonBody.Contains(word)))
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new { message = "Bu gönderide hoş olmayan kelimeler var!" });

                return;

            }

            await _next(context);

        }
    }
}
