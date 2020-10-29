using System;
using FluentAssertions;
using InnoTech.Infrastructure.Adapters.SQLData.Repositories;
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
        public void LocationRepositoryShouldBeILocationRepository_WithEggProductionDbContextAsNullParam_ThrowsException()
        {
            Action action = () => new LocationRepository(null as EggProductionDbContext);
            action.Should().Throw<NullReferenceException>(); 
        }
    }
}