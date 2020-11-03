using InnoTech.Infrastructure.Adapters.SQLData;
using InnoTech.Infrastructure.Adapters.SQLData.Repositories;

namespace InnoTech.Test.Helpers.Locations
{
    public class LocationRepositoryTestHelper
    {
        private LocationEntityTestHelper _locationEntityTestHelper;

        public LocationRepositoryTestHelper()
        {
            _locationEntityTestHelper = new LocationEntityTestHelper();
        }
        
        public LocationRepository GetValidLocationRepository()
        {
            return new LocationRepository(new EggProductionDbContext());
        }

        public LocationRepository GetLocationRepository(EggProductionDbContext context)
        {
            return new LocationRepository(new EggProductionDbContext());
        }
    }

}