using System;
using InnoTech.Core.Entity;
using InnoTech.Core.InfratructurePorts.Repositories;
using InnoTech.Core.PrimaryDriverAdapters.Exceptions;
using InnoTech.Core.PrimaryDriverAdapters.Validators;
using InnoTech.Core.PrimaryDriverPorts.Services;
using InnoTech.Core.PrimaryDriverPorts.Validators;

namespace InnoTech.Core.PrimaryDriverAdapters.Services
{
    public class LocationService: ILocationService
    {
        private ILocationValidator _locationValidator;

        public LocationService(ILocationRepository locationRepository, ILocationValidator locationValidator)
        {
            if(locationRepository == null) {
                throw new ParameterCannotBeNullException("LocationRepository");
            }
            if(locationValidator == null) {
                throw new ParameterCannotBeNullException("LocationValidator");
            }

            _locationValidator = locationValidator;
        }

        public void Create(Location location)
        {
            _locationValidator.DefaultValidation(location);
        }
    }
}