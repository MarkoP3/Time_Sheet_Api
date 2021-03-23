using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using timeSheet.Services.Data;
using timeSheet.Services.Services;

namespace timeSheetApi
{
    public class Startup
    {

        private readonly string FrontendOrigins = "FrontendOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: FrontendOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000");
                                      builder.AllowAnyHeader();
                                      builder.AllowAnyMethod();
                                  });
            });
            services.AddControllers();

            services.AddSingleton<IClientRepository, mockClientRepository>();
            services.AddSingleton<ICountryRepository, mockCountryRepository>();
            services.AddSingleton<IProjectRepository, mockProjectRepository>();
            services.AddSingleton<ITeamMemberRepository, mockTeamMembersRepository>();
            services.AddSingleton<IClientServices, ClientServices>();
            services.AddScoped<IProjectServices, ProjectServices>();
            services.AddScoped<ICountryServices, CountryServices>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "timeSheet.WebApi", Version = "v1" });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            /*services.AddDbContext<TimeSheetContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(Configuration.GetConnectionString("TimeSheet"));
            });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "timeSheetApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(FrontendOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
