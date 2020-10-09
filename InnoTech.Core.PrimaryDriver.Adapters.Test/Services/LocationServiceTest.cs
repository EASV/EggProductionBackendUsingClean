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
            Assert.Throws<NullReferenceException>(() => new LocationService(locationRepository));
        }
        
        [Fact]
        public void CreateNewLocationServiceOfTypeILocationService_WithNullAsILocationRepository_ThrowsNullReferenceExceptionWithCorrectText()
        {
            ILocationRepository locationRepository = null;
            try
            {
                new LocationService(locationRepository);
                Assert.True(false, "This should not happen you should throw exception");
            }
            catch (NullReferenceException e)
            {
                Assert.Equal("You need to have a Repository to use the Service", e.Message);
            }
        }
    }
}