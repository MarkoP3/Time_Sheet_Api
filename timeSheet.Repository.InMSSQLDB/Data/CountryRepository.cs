using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using timeSheet.Repository.Contract.Data;
using timeSheet.Repository.InMSSQLDB.EntitiesDB;

namespace timeSheet.Repository.InMSSQLDB.Data
{
    public class CountryRepository : ICountryRepository
    {
        public CountryRepository(TimeSheetContext context, IMapper mapper)
        {
            Context = context;
            Mapper = TimeSheetDBMapper.Mapper;
        }

        public TimeSheetContext Context { get; }
        public IMapper Mapper { get; }

        public IList<Contract.Entities.Country> GetAllCountries()
        {
            return Mapper.Map<IList<Contract.Entities.Country>>(Context.Countries.ToList());
        }
    }
}
