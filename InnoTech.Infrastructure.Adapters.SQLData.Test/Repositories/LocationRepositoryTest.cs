using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using InnoTech.Core.Entity;
using InnoTech.Core.InfratructurePorts.Repositories;
using InnoTech.Test.Helpers.Entities;
using InnoTech.Test.Helpers.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;

namespace InnoTech.Infrastructure.Adapters.SQLData.Test.Repositories
{
    public class LocationRepositoryTest
    {
        private readonly LocationRepositoryTestHelper _repoHelper;
        private readonly LocationEntityTestHelper _entityHelper;

        public LocationRepositoryTest()
        {
            _repoHelper = new LocationRepositoryTestHelper();
            _entityHelper = new LocationEntityTestHelper();
        }
        [Fact]
        public void CreateALocationRepository_WithEggProductionDbContextAsNullParam_ThrowsException()
        {
            Action createIt = () => _repoHelper.GetLocationRepository(null);
            createIt.Should().Throw<NullReferenceException>();
        }
        
        [Fact]
        public void LocationRepository_ShouldImplementILocationRepository()
        {
            var repo = _repoHelper.GetValidLocationRepository();
            repo.Should().BeAssignableTo<ILocationRepository>();
        }
        
        [Fact]
        public void AddInLocationRepository_WithANullLocation_ThrowsException()
        {
            var validLocationRepo = _repoHelper.GetValidLocationRepository(); 
            Action action = () => validLocationRepo.Add(null);
            action.Should().Throw<NullReferenceException>();
        }
        
        [Fact]
        public void Add_WithValidLocation_CallsAddOnDBContext()
        {
            var contextMock = new Mock<EggProductionDbContext>();
            var repo = _repoHelper.GetLocationRepository(contextMock.Object);
            var location = _entityHelper.ValidLocation();
            repo.Add(location);
            contextMock.Verify(c => c.Add(location), Times.Once);
        }

        [Fact]
        public void Add_WithValidLocation_AddsItToDbSetChangeTrackerList()
        {
            var location = _entityHelper.ValidLocation();
            var changeTrackerListLocations = new List<Location>();
            var contextMock = new Mock<EggProductionDbContext>();
            contextMock.Setup(c => c.Add(location))
                .Callback<Location>(l => changeTrackerListLocations.Add(l));
            var repo = _repoHelper.GetLocationRepository(contextMock.Object);
            repo.Add(location);
            Assert.Equal(location, changeTrackerListLocations.First());
        }
    }
}