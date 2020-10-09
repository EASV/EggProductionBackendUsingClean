using System;
using InnoTech.Core.InfratructurePorts.Repositories;
using InnoTech.Core.PrimaryDriverAdapters.Services;
using InnoTech.Core.PrimaryDriverPorts.Services;
using Xunit;

namespace InnoTech.Core.PrimaryDriver.Adapters.Test.Services
{
    public class LocationServiceTest
    {
        [Fact]
        public void CreateNewLocationServiceOfTypeILocationService_WithNullAsILocationRepository_ThrowsNullReferenceException()
        {
            ILocationRepository locationRepository = null;
            ILocationService locationService = new LocationService(locationRepository);
            Assert.Throws<NullReferenceException>(() => true);
        }
    }
}