using AutoMapper;
using System;
using timeSheetApi.Profiles;

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
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
}
