using InnoTech.Core.InfratructurePorts.Repositories;
using InnoTech.Core.PrimaryDriverPorts.Services;

namespace InnoTech.Core.PrimaryDriverAdapters.Services
{
    public class LocationService: ILocationService
    {
        public LocationService(ILocationRepository locationRepository)
        {
            
        }
    }
}