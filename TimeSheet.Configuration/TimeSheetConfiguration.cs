using Microsoft.Extensions.DependencyInjection;
using timeSheet.Repository.Contract.Data;
using timeSheet.Repository.InMSSQLDB.Data;
using timeSheet.Services.Contract.Services;
using timeSheet.Services.Services;

namespace timeSheet.Configuration
{
    public static class TimeSheetConfiguration
    {
        public static void AddTimeSheetServices(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
            services.AddScoped<IClientServices, ClientServices>();
            services.AddScoped<IProjectServices, ProjectServices>();
            services.AddScoped<ICountryServices, CountryServices>();
            services.AddScoped<ITeamMemberServices, TeamMemberServices>();
        }

    }
}
