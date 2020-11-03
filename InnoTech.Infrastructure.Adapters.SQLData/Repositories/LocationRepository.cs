using System;
using InnoTech.Core.Entity;
using InnoTech.Core.InfratructurePorts.Repositories;

namespace InnoTech.Infrastructure.Adapters.SQLData.Repositories
{
    public class LocationRepository: ILocationRepository
    {
        private readonly EggProductionDbContext _ctx;

        public LocationRepository(EggProductionDbContext ctx)
        {
            if (ctx == null)
            {
                throw new NullReferenceException();
            }
            _ctx = ctx;
        }

        public void Add(Location location)
        {
            if (location == null)
            {
                throw new NullReferenceException();
            }

            //Your looking for a table with the type location,
            //find the correct dbset
            _ctx.Add(location);
        }
    }
}