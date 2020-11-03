using InnoTech.Infrastructure.Adapters.SQLData;
using InnoTech.Infrastructure.Adapters.SQLData.Repositories;
using InnoTech.Test.Helpers.Entities;

namespace InnoTech.Test.Helpers.Repositories
{
    public class LocationRepositoryTestHelper
    {
        public LocationRepository GetValidLocationRepository()
        {
            return new LocationRepository(new EggProductionDbContext());
        }

        public LocationRepository GetLocationRepository(EggProductionDbContext context)
        {
            return new LocationRepository(context);
        }
    }

}