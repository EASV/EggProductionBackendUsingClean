using System;
using FluentAssertions;
using InnoTech.Core.Entity;
using InnoTech.Core.InfratructurePorts.Repositories;
using InnoTech.Core.PrimaryDriverAdapters.Exceptions;
using InnoTech.Core.PrimaryDriverAdapters.Services;
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
            Action action = () => new LocationService(locationRepository);
            action.Should()
                .Throw<ParameterCannotBeNullException>()
                .WithMessage("LocationRepository Parameter Cannot be null");

        }

        [Fact]
        public void Create_WithLocationAsNull_ThrowsParameterCannotBeNullExceptionWithLocationMessage()
        {
            ILocationRepository locationRepository = new Mock<ILocationRepository>().Object;
            ILocationService locationService = new LocationService(locationRepository);
            Action action = () => locationService.Create(null as Location);
            action.Should()
                .Throw<ParameterCannotBeNullException>()
                .WithMessage("Location Parameter Cannot be null");
            /*var exception = Assert.Throws<NullReferenceException>(() => locationService.Create(null as Location));
            Assert.Equal("Location Cannot Be Null", exception.Message);*/
        }
        
        
    }
}