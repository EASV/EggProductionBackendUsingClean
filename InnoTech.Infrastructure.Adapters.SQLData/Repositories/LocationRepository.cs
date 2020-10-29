using System;

namespace InnoTech.Infrastructure.Adapters.SQLData.Repositories
{
    public class LocationRepository
    {
        public LocationRepository(EggProductionDbContext ctx)
        {
            if (ctx == null)
            {
                throw new NullReferenceException();
            }
        }
    }
}