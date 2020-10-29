using System;
using InnoTech.Core.Entity;
using InnoTech.Core.InfratructurePorts.Repositories;

namespace InnoTech.Infrastructure.Adapters.SQLData.Repositories
{
    public class LocationRepository: ILocationRepository
    {
        public LocationRepository(EggProductionDbContext ctx)
        {
            if (ctx == null)
            {
                throw new NullReferenceException();
            }
        }

        public void Add(Location location)
        {
            if (location == null)
            {
                throw new NullReferenceException();
            }
        }
    }
}