using System;
using InnoTech.Core.Entity;
using InnoTech.Core.InfratructurePorts.Repositories;
using InnoTech.Core.PrimaryDriverAdapters.Exceptions;
using InnoTech.Core.PrimaryDriverPorts.Services;

namespace InnoTech.Core.PrimaryDriverAdapters.Services
{
    public class LocationService: ILocationService
    {
        public LocationService(ILocationRepository locationRepository)
        {
            if(locationRepository == null) {
                throw new ParameterCannotBeNullException("LocationRepository");
            }
        }

        public void Create(Location location)
        {
            if (location == null)
            {
                throw new ParameterCannotBeNullException("Location");
            }

            if (string.IsNullOrEmpty(location.Name))
            {
                throw new PropertyCannotBeEmptyException("Name");
            }

            if (location.Name.Length < 2)
            {
                throw new ArgumentOutOfRangeException("Name Must be 2 or more Characters");
            }
        }
    }
}