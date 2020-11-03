using FluentAssertions;
using InnoTech.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace InnoTech.Infrastructure.Adapters.SQLData.Test
{
    public class EggProductionDbContextTest
    {
        [Fact]
        public void EggProductionDbContext_IsOfTypeDbContext()
        {
            var context = new EggProductionDbContext();
            context.Should().BeAssignableTo<DbContext>();
        }

        [Fact]
        public void EggProductionDbContext_ShouldHaveDbSetWithLocations()
        {
            var context = new EggProductionDbContext();
            context.Locations.Should().BeAssignableTo<DbSet<Location>>();
        }
    }
}