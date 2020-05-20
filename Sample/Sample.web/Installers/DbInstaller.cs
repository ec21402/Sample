using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.web.Data;

namespace Sample.Installers
{
    public static class DbInstaller
    {
        public static IServiceCollection AddDatabase(this IServiceCollection service, IConfiguration configuration)
        {
            return service.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
