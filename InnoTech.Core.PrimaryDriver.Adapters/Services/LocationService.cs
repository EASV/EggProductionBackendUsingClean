using System;
using InnoTech.Core.Entity;
using InnoTech.Core.InfratructurePorts.Repositories;
using InnoTech.Core.PrimaryDriverPorts.Services;

namespace InnoTech.Core.PrimaryDriverAdapters.Services
{
    public class LocationService: ILocationService
    {
        public LocationService(ILocationRepository locationRepository)
        {
            if(locationRepository == null) {
                throw new NullReferenceException("You need to have a Repository to use the Service");
            }
        }

        public void Create(Location location)
        {
            if (location == null)
            {
                throw new NullReferenceException("Location Cannot Be Null");
            }
        }
    }
}