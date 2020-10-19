using System;
using FluentAssertions;
using InnoTech.Core.Entity;
using InnoTech.Core.InfratructurePorts.Repositories;
using InnoTech.Core.PrimaryDriverAdapters.Exceptions;
using InnoTech.Core.PrimaryDriverAdapters.Services;
using InnoTech.Core.PrimaryDriverAdapters.Validators;
using InnoTech.Core.PrimaryDriverPorts.Services;
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
        public void CreateNewLocationServiceOfTypeILocationService_WithNullAsLocationValidator_ThrowsNullReferenceException()
        {
            ILocationRepository locationRepository = new Mock<ILocationRepository>().Object;
            Action action = () => new LocationService(locationRepository, null as LocationValidator);
            action.Should()
                .Throw<ParameterCannotBeNullException>()
                .WithMessage("LocationValidator Parameter Cannot be null");
        }
        
    }
}