using eshop.Application.MappingProfile;
using eshop.Application.Services;
using eshop.Infrastructure.Data;
using eshop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace eshop.Common.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddIoCAndMapping(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, EFProductRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(typeof(MapProfile));
            services.AddDbContext<EshopDbContext>(option => option.UseSqlServer(connectionString));

            return services;
        }
    }
}
