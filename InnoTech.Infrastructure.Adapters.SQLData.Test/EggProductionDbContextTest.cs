using FluentAssertions;
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
    }
}