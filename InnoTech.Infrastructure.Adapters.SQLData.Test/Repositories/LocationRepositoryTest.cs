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
        public void AddInLocationRepositoryAsILocationRepository_WithANullLocation_ThrowsException()
        {
            var context = new Mock<EggProductionDbContext>().Object;
            var repo = new LocationRepository(context) as ILocationRepository;
            Action action = () => repo.Add(null as Location);
            action.Should().Throw<NullReferenceException>();
        }
        
        [Fact]
        public void Add_WithValidLocation_CallsAddOnDBContext()
        {
            
        }
        
        
    }
}