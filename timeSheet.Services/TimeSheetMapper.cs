using AutoMapper;
using System;
using timesheet.Services.Profiles;

namespace timeSheet.Services
{
    public static class TimeSheetMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<ClientProfile>();
                cfg.AddProfile<CountryProfile>();
                cfg.AddProfile<ProjectProfile>();
                cfg.AddProfile<TeamMemberProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
}
