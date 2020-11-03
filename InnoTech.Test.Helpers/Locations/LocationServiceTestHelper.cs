using System;
using FluentAssertions;
using InnoTech.Core.Entity;
using InnoTech.Core.InfratructurePorts.Repositories;
using InnoTech.Core.PrimaryDriverAdapters.Services;
using InnoTech.Core.PrimaryDriverPorts.Services;
using InnoTech.Core.PrimaryDriverPorts.Validators;
using Moq;

namespace InnoTech.Test.Helpers.Locations
{
    public class LocationServiceTestHelper
    {
        private LocationEntityTestHelper _locationEntityTestHelper;

        public LocationServiceTestHelper()
        {
            _locationEntityTestHelper = new LocationEntityTestHelper();
        }
        public void CreateInvalid<T>(
            ILocationRepository repository = null, 
            ILocationValidator validator = null,
            Location location = null,
            string message = null) where T : Exception
        {
            Action action = () => LocationService(repository, validator).Create(location);
            if (message != null)
            {
                action.Should().Throw<T>()
                    .And.Message.Should().Be(message);
            }
            else
            {
                action.Should().Throw<T>();
            }
        }

        public Location CreateVerify(
            ILocationRepository locationRepository = null, 
            ILocationValidator validator= null)
        {
            locationRepository ??= new Mock<ILocationRepository>().Object;
            validator ??= new Mock<ILocationValidator>().Object;
            
            var service = new LocationService(locationRepository, validator) as ILocationService;
            var location = _locationEntityTestHelper.ValidLocation();
            service.Create(location);
            return location;
        }

        public Mock<ILocationRepository> LocationRepositoryMock()
        {
            return new Mock<ILocationRepository>();
        }
        
        public Mock<ILocationValidator> LocationValidatorMock()
        {
            return new Mock<ILocationValidator>();
        }

        private ILocationService LocationService(
            ILocationRepository repository = null, 
            ILocationValidator validator = null)
        {
            return new LocationService(repository, validator);
        }
    }
}