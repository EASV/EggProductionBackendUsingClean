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
        private readonly ILocationValidator _locationValidator;
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository, ILocationValidator locationValidator)
        {
            _locationRepository = locationRepository ?? throw new ParameterCannotBeNullException("LocationRepository");
            _locationValidator = locationValidator ?? throw new ParameterCannotBeNullException("LocationValidator");
        }

        public void Create(Location location)
        {
            _locationValidator.DefaultValidation(location);
            _locationRepository.Add(location);
        }
    }
}