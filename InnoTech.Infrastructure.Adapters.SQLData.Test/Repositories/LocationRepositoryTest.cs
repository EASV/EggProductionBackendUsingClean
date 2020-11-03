using System;
using FluentAssertions;
using InnoTech.Core.InfratructurePorts.Repositories;
using InnoTech.Infrastructure.Adapters.SQLData.Repositories;
using InnoTech.Test.Helpers.Locations;
using Moq;
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
            Action createIt = () => new LocationRepository(null);
            createIt.Should().Throw<NullReferenceException>();
        }
        
        [Fact]
        public void LocationRepository_ShouldImplementILocationRepository()
        {
            var context = new Mock<EggProductionDbContext>().Object;
            var repo = new LocationRepository(context);
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
        
        
    }
}