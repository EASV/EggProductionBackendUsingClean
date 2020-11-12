using InnoTech.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace InnoTech.Infrastructure.Adapters.SQLData
{
    public class EggProductionDbContext: DbContext
    {
       public virtual DbSet<Location> Locations { get; set; }
    }
    
}