using System;
using FluentAssertions;
using InnoTech.Core.Entity;
using InnoTech.Core.InfratructurePorts.Repositories;
using InnoTech.Infrastructure.Adapters.SQLData.Repositories;
using Moq;
using Xunit;

namespace InnoTech.Infrastructure.Adapters.SQLData.Test.Repositories
{
    public class LocationRepositoryTest
    {
        [Fact]
        public void CreateALocationRepository_WithEggProductionDbContextAsNullParam_ThrowsException()
        {
            Action action = () => new LocationRepository(null as EggProductionDbContext);
            action.Should().Throw<NullReferenceException>(); 
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
            var context = new Mock<EggProductionDbContext>().Object;
            var repo = new LocationRepository(context) as ILocationRepository;
            Action action = () => repo.Add(null as Location);
            action.Should().Throw<NullReferenceException>();
        }
        
        [Fact]
        public void Add_WithValidLocation_CallsAddOnDBContext()
        {
            var contextMock = new Mock<EggProductionDbContext>();
            var repo = new LocationRepository(contextMock.Object);
            var location = new Location{Id = 0, Address = "The Street", Name = "The Hut", Owner = "John Doe"};
            repo.Add(location);
            contextMock.Verify(c => c.Add(location), Times.Once);
        }
        
        
    }
}