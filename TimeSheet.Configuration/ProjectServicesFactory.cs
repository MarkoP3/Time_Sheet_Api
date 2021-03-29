using Microsoft.EntityFrameworkCore;
using timeSheet.Repository.InMSSQLDB.Data;
using timeSheet.Repository.InMSSQLDB.EntitiesDB;
using timeSheet.Services;
using timeSheet.Services.Contract.Services;
using timeSheet.Services.Services;

namespace timeSheet.Configuration
{
    public class ProjectServicesFactory
    {
        public IProjectServices GetProjectServices()
        {
            DbContextOptionsBuilder<TimeSheetContext> builder = new DbContextOptionsBuilder<TimeSheetContext>();
            builder.UseSqlServer("Server=.\\SQLExpress;Database=TimeSheet;Trusted_Connection=True;");
            builder.UseLazyLoadingProxies();
            return new ProjectServices(new ProjectRepository(new TimeSheetContext(builder.Options), TimeSheetMapper.Mapper));
        }
    }
}
