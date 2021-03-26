using AutoMapper;
using System;
using timeSheet.Repository.InMSSQLDB.Profiles;

namespace timeSheet.Repository.InMSSQLDB
{
    public class TimeSheetDBMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
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
