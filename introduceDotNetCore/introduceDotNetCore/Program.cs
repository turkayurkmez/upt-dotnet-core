var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSession(option => option.IdleTimeout = TimeSpan.FromMinutes(20));

var app = builder.Build();

/*
 * Middleware - pipeline
 *   1. Şişeyi soda ile doldur
 *   2. Şişeye etiket bas -> Middleware *  
 *   3. Şişeyi kapat
 *   4. Şişeyi koliye yerleştir.
 *   
 *   Middleware: ne yapacağım?
 *   Pipe-line: hangi sırayla yapacağım?
 */

app.UseStaticFiles();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

//app.MapGet("/", () => "Hello World!");

app.Run();
