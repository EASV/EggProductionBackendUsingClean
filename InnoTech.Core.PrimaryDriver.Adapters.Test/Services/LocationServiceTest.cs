using System;
using FluentAssertions;
using InnoTech.Core.Entity;
using InnoTech.Core.InfratructurePorts.Repositories;
using InnoTech.Core.PrimaryDriverAdapters.Exceptions;
using InnoTech.Core.PrimaryDriverAdapters.Services;
using InnoTech.Core.PrimaryDriverAdapters.Validators;
using InnoTech.Core.PrimaryDriverPorts.Validators;
using Moq;
using Xunit;

namespace InnoTech.Core.PrimaryDriver.Adapters.Test.Services
{
    public class LocationServiceTest
    {
        [Fact]
        public void CreateNewLocationServiceOfTypeILocationService_WithNullAsILocationRepository_ThrowsNullReferenceException()
        {
            ILocationRepository locationRepository = null;
            Action action = () => new LocationService(locationRepository, null);
            action.Should()
                .Throw<ParameterCannotBeNullException>()
                .WithMessage("LocationRepository Parameter Cannot be null");
        }
        
        [Fact]
        public void CreateNewLocationServiceOfTypeILocationService_WithNullAsILocationValidator_ThrowsNullReferenceException()
        {
            ILocationRepository locationRepository = new Mock<ILocationRepository>().Object;
            ILocationValidator validator = null as LocationValidator;
            Action action = () => new LocationService(locationRepository, validator);
            action.Should()
                .Throw<ParameterCannotBeNullException>()
                .WithMessage("LocationValidator Parameter Cannot be null");
        }

        [Fact]
        public void Create_WithLocationParameter_ShouldCallILocationValidatorsDefaultValidationMethodOneTime()
        {
            Mock<ILocationRepository> locationRepositoryMock = new Mock<ILocationRepository>();
            Mock<ILocationValidator> locationValidatorMock = new Mock<ILocationValidator>();
            LocationService locationService = new LocationService(locationRepositoryMock.Object, locationValidatorMock.Object);
            Location location = new Location
            {
                Name = "The Village"
            };
            locationService.Create(location);
            locationValidatorMock.Verify(lm => lm.DefaultValidation(location), Times.Once);
        }
    }
}