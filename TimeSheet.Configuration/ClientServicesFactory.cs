using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using timeSheet.Repository.InMSSQLDB.Data;
using timeSheet.Repository.InMSSQLDB.EntitiesDB;
using timeSheet.Services;
using timeSheet.Services.Contract.Services;
using timeSheet.Services.Services;

namespace timeSheet.Configuration
{
    public class ClientServicesFactory
    {
        public IClientServices GetClientService(IConfiguration configuration)
        {
            DbContextOptionsBuilder<TimeSheetContext> builder = new DbContextOptionsBuilder<TimeSheetContext>();
            builder.UseSqlServer(configuration.GetConnectionString("TimeSheet"));
            builder.UseLazyLoadingProxies();
            return new ClientServices(new ClientRepository(new TimeSheetContext(builder.Options), TimeSheetMapper.Mapper));
        }
    }
}
