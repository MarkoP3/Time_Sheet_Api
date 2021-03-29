using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using timeSheet.Repository.InMSSQLDB.Data;
using timeSheet.Repository.InMSSQLDB.EntitiesDB;
using timeSheet.Services;
using timeSheet.Services.Contract.Services;
using timeSheet.Services.Services;

namespace timeSheet.Configuration
{
    public class TimeSheetApp
    {
        public TimeSheetApp(IConfiguration config)
        {
            Config = config;
        }

        private IConfiguration Config { get; }
        private TimeSheetContext GetDbContext()
        {
            DbContextOptionsBuilder<TimeSheetContext> builder = new DbContextOptionsBuilder<TimeSheetContext>();
            builder.UseSqlServer(Config.GetConnectionString("TimeSheet"));
            builder.UseLazyLoadingProxies();
            return new TimeSheetContext(builder.Options);
        }
        public IClientServices GetClientService()
        {

            return new ClientServices(new ClientRepository(GetDbContext(), TimeSheetMapper.Mapper));

        }
    }
}
