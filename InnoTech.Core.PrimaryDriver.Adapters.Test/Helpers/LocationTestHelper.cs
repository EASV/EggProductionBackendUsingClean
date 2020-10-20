using InnoTech.Core.Entity;

namespace InnoTech.Core.PrimaryDriver.Adapters.Test.Helpers
{
    public class LocationTestHelper
    {
        public Location Location(string name = "")
        {
            return new Location
            {
                Name = name
            };
        }

        public Location ValidLocation()
        {
            return new Location
            {
                Name = "The Place"
            };
        }
    }
}