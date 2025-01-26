using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagiment_DataAccess.Persistence;

namespace TaskManagiment_DataAccess
{
    public static class DataAccessDependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddIdentity();
            services.AddRepositories();
            return services;
        }

        private static void AddRepositories(this IServiceCollection services)
        {





        }

        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseConfig = configuration.GetSection("Database").Get<DatabaseConfiguration>;

            if (databaseConfig.UseInMemoryDatabase)
            {
                services.AddDbContext<DataBaseContext>(options =>
                    options.UseInMemoryDatabase("TaskManagimentDatabase"));
            }
            else
            {
                services.AddDbContext<DataBaseContext>(options =>
                    options.UseNpgsql(databaseConfig.ConnectionString,
                        npgsqlOptions => npgsqlOptions.MigrationsAssembly(typeof(DataBaseContext).Assembly.FullName)));
            }
        }

        private static void AddIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DataBaseContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });
        }
    }

    public class DatabaseConfiguration
    {
        public bool UseInMemoryDatabase { get; set; }
        public string ConnectionString { get; set; }
    }
}
