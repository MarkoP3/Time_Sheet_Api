using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using timeSheet.Services.Contract.Services;

namespace timeSheet.Configuration
{
    public static class TimeSheetConfiguration
    {
        public static IServiceCollection AddTimeSheetServices(this IServiceCollection services, IConfiguration configuration)
        {
            /*services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
            services.AddScoped<IClientServices, ClientServices>();
            services.AddScoped<IProjectServices, ProjectServices>();
            services.AddScoped<ICountryServices, CountryServices>();
            services.AddScoped<ITeamMemberServices, TeamMemberServices>();
            services.AddDbContext<TimeSheetContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(configuration.GetConnectionString("TimeSheet"));
            });*/
            TimeSheetApp timeSheetApp = new TimeSheetApp(configuration);
            services.AddScoped<IClientServices>(_=> timeSheetApp.GetClientService());
            return services;
        }

    }
}
