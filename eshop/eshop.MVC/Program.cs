using eshop.Common.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddIoCAndMapping(connectionString);
//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<IProductRepository, EFProductRepository>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();
//builder.Services.AddScoped<IUserService, UserService>();

//builder.Services.AddAutoMapper(typeof(MapProfile));

//builder.Services.AddDbContext<EshopDbContext>(option => option.UseSqlServer(connectionString));


builder.Services.AddSession();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/Users/Login";
                    option.ReturnUrlParameter = "gidilecekSayfa";
                    option.AccessDeniedPath = "/Users/AccessDenied";
                });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
